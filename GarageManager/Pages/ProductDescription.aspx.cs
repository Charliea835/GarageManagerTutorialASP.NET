using GarageManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager.Pages
{
    public partial class ProductDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) ;
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ProductModel productModel = new ProductModel();
                Product product = productModel.getProduct(id);

                //fill page with data
                lblPrice.Text = "$ " + product.Price;
                lblTitle.Text = product.Name;
                lblDescription.Text = product.Description;
                lblItemNr.Text = id.ToString();
                imgProduct.ImageUrl = "~/Images/Products/" + product.Image;

                //fill droplist with numbers 

                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
             {
                string clientId =Context.User.Identity.GetUserId();
                if (clientId != null)
                {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                Purchase purchase = new Purchase
                {
                    Amount = amount,
                    CustomerID = clientId,
                    Date = DateTime.Now,
                    IsInCart = true,
                    ProductID = id

                };

                PurchaseModel model = new PurchaseModel();
                lblResult.Text = model.insertPurchase(purchase);
                System.Diagnostics.Debug.WriteLine(model.insertPurchase(purchase));
               }
               else
                {
                    lblResult.Text = "Please log in to order items";
                }
            }
        }
    }
}