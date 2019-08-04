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

        public List<Purchase>getOrdersInCart(string userID)
        {
            GarageDBEntities db = new GarageDBEntities();
            List<Purchase> orders = (from x in db.Purchases
                                      where x.CustomerID == userID
                                      && x.IsInCart
                                      orderby x.Date
                                      select x).ToList();
            return orders;
        }

        public int getAmountOfOrders(string userID)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                int amount = (from x in db.Purchases
                              where x.CustomerID == userID
                              && x.IsInCart
                              select x.Amount).Sum();
                return amount;
            }
            catch
            {
                return 0;
            }
        }

        public void updateQuantity(int id, int quantity)
        {
            GarageDBEntities db = new GarageDBEntities();
            Purchase purchase = db.Purchases.Find(id);
            purchase.Amount = quantity;
            db.SaveChanges();
        }

        public void markOrdersAsPaid(List<Purchase>purchases)
        {
            GarageDBEntities db = new GarageDBEntities();
            if (purchases != null)
            {
                foreach(Purchase purchase in purchases)
                {
                    Purchase oldPurchases = db.Purchases.Find(purchase.ID);
                    oldPurchases.Date = DateTime.Now;
                    oldPurchases.IsInCart = false;
                }
                db.SaveChanges();
            }
        }
    }
}