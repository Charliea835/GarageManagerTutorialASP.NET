using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager.Pages.Management
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridProducts.Rows[e.NewEditIndex];

            int rowID = Convert.ToInt32(row.Cells[1].Text);

            Response.Redirect("~/Pages/Management/ManageProducts.aspx?id=" + rowID);
        }

        
    }
}