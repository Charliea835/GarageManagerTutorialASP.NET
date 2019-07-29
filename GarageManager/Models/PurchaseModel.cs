using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class PurchaseModel
    {

        public string insertPurchase(Purchase purchase)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                db.Purchases.Add(purchase);
                db.SaveChanges();

                return purchase.Date + " was succesfully added to cart";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string updatePurchase(int id, Purchase purchase)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();

                Purchase p = db.Purchases.Find(id);

                p.Date = purchase.Date;
                p.CustomerID = purchase.CustomerID;
                p.Amount = purchase.Amount;
                p.IsInCart = purchase.IsInCart;
                p.ProductID = purchase.ProductID;

                db.SaveChanges();

                return purchase.Date + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string deletePurchase(int id)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                Purchase purchase = db.Purchases.Find(id);

                db.Purchases.Attach(purchase);
                db.Purchases.Remove(purchase);
                db.SaveChanges();

                return purchase.Date + " was succesfully deleted";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}