using GarageManager.Models;
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
    public partial class Register : System.Web.UI.Page
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

            //create a new user and try to store connection in db
            IdentityUser user = new IdentityUser();
            user.UserName = txtUsername.Text;

            if (txtPassword.Text == txtConfpassword.Text)
            {
                try
                {
                    IdentityResult result = manager.Create(user,txtPassword.Text);

                    if (result.Succeeded)
                    {

                        UserInformation info = new UserInformation
                        {
                            Address = txtAddress.Text,
                            firstName = txtFirstName.Text,
                            lastName = txtLastName.Text,
                            PostalCode = txtPostalCode.Text,
                            GUID = user.Id,
                        };

                        UserInfoModel model = new UserInfoModel();
                        model.insertUserInformation(info);

                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;


                        //set to log in user by cookies
                        var userIdentity =manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        //log in new user and redirect them to homepage
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("/Pages/Index.aspx");
                    }
                    else
                    {
                        litStatus.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch(Exception ex)
                {
                    litStatus.Text = ex.ToString();
                }
            }
            else
            {
                litStatus.Text = "Passwords must match";
            }
        }
    }
}