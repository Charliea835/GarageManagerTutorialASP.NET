using GarageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            ProductModel productModel = new ProductModel();
            List<Product> products = productModel.getAllProducts();

            if (products != null)
            {
                foreach(Product product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton();
                    Label lblName = new Label();
                    Label lblPrice = new Label();

                    //set child control properties
                    imageButton.ImageUrl = "../Images/Products/" + product.Image;
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "/Pages/ProductDescription.aspx?id=" + product.ID;

                    lblName.Text = product.Name;
                    lblName.CssClass = "productName";

                    lblPrice.Text = "$ " + product.Price;
                    lblPrice.CssClass = "productPrice";

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblPrice);

                    //add dynamic panels to static panel
                    PanelProducts.Controls.Add(productPanel);

                }
            }
            else
            {
                //no products found
                PanelProducts.Controls.Add(new Literal { Text = "No products found" });
            }
        }
    }
}