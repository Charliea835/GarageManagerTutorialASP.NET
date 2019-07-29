using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class UserInfoModel
    {
        public UserInformation getUserInformation(string guid)
        {
            GarageDBEntities db = new GarageDBEntities();
            UserInformation info = (from x in db.UserInformations where x.GUID==guid
                                    select x).FirstOrDefault();

            return info;
        }

        public void insertUserInformation(UserInformation info)
        {
            GarageDBEntities db = new GarageDBEntities();
            db.UserInformations.Add(info);
            db.SaveChanges();
        }
    }
}