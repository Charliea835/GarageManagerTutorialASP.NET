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
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Purchase> carts = (List<Purchase>)Session[User.Identity.GetUserId()];

            PurchaseModel purchase = new PurchaseModel();
            purchase.markOrdersAsPaid(carts);

            Session[User.Identity.GetUserId()] = null;
        }
    }
}