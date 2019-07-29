using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using GarageManager.Models;

namespace GarageManager.Pages.Management
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getImages();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    fillPage(id);
                }
            }
        }

        public void fillPage(int id)
        {
            ProductModel productModel = new ProductModel();
            Product product = productModel.getProduct(id);

            txtDescription.Text = product.Description;
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();

            ddlImages.SelectedValue = product.Image;
            ddlType.SelectedValue = product.TypeID.ToString();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
                
        }

        private void getImages()
        {
            try
            {
                String[] images = Directory.GetFiles(Server.MapPath("~/Images/Products"));

                ArrayList imageList = new ArrayList();
                foreach(string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }

                ddlImages.DataSource = imageList;
                ddlImages.AppendDataBoundItems = true;
                ddlImages.DataBind();
            }
            catch(Exception e)
            {
                LblResult.Text = e.ToString();
            }
        }

        private Product createProduct()
        {
            
            Product product = new Product();
            product.Name = txtName.Text;
            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
            product.Description = txtDescription.Text;
            product.Image = ddlImages.SelectedValue;
            return product;

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            Product product = createProduct();
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LblResult.Text = productModel.updateProduct(id,product);
            }
            else{

                LblResult.Text = productModel.insertProduct(product);
            }
           
        }
    }
}