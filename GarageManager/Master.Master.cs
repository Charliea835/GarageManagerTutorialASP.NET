using GarageManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            if (user.IsAuthenticated)
            {

                litStatus.Text = Context.User.Identity.Name;
                loginLink.Visible = false;
                linkRegister.Visible = false;
                linkLogout.Visible = true;
                litStatus.Visible = true;

                PurchaseModel model = new PurchaseModel();
                string userId = HttpContext.Current.User.Identity.GetUserId();
                litStatus.Text = string.Format("{0}({1})", Context.User.Identity.Name, model.getAmountOfOrders(userId));
            }
            else
            {
                loginLink.Visible = true;
                linkRegister.Visible = true;
                linkLogout.Visible = false;
                litStatus.Visible = false;
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            Response.Redirect("/Pages/Index.aspx");
        }
    }
}