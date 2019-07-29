using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class ProductModel
    {
        public string insertProduct(Product product)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                db.Products.Add(product);
                db.SaveChanges();

                return product.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string updateProduct(int id, Product product)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();

                Product p = db.Products.Find(id);

                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeID = product.TypeID;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();

                return product.Name + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string deleteProduct(int id)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                Product product = db.Products.Find(id);

                db.Products.Attach(product);
                db.Products.Remove(product);
                db.SaveChanges();

                return product.Name + " was succesfully deleted";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public Product getProduct(int id)
        {
            try
            {
                using (GarageDBEntities db = new GarageDBEntities())
                {
                    Product product = db.Products.Find(id);
                    return product;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> getAllProducts()
        {
            try
            {
                using (GarageDBEntities db = new GarageDBEntities())
                {
                    List<Product> products = (from x in db.Products select x).ToList();
                    return products;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Product>getProductByType(int typeID)
        {
            try
            {
                using (GarageDBEntities db = new GarageDBEntities())
                {
                    List<Product> products = (from x in db.Products where x.TypeID==typeID select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}