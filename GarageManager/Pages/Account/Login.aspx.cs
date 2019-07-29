using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["GarageDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;


                //set to log in user by cookies
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //sign in user
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false,
                },userIdentity);

                Response.Redirect("/Pages/Index.aspx");
            }
            else
            {
                litStatus.Text = "Invalid username or password";
            }
        }
    }
}