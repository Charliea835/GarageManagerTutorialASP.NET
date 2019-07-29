using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class ProductTypeModel
    {

        public string insertProductType(ProductType productType)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                db.ProductTypes.Add(productType);
                db.SaveChanges();

                return productType.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string updateProductType(int id, ProductType productType)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();

                ProductType p = db.ProductTypes.Find(id);

                p.Name = productType.Name;
                

                db.SaveChanges();

                return productType.Name + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string deleteProductType(int id)
        {
            try
            {
                GarageDBEntities db = new GarageDBEntities();
                ProductType productType = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productType);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType.Name + " was succesfully deleted";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}