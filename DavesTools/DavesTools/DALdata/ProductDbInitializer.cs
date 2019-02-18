using DavesTools.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace DavesTools.DALdata
{
    internal class ProductDbInitializer : CreateDatabaseIfNotExists<ProductDBcontext>
    {
        protected override void Seed(ProductDBcontext context)
        {
            var products = new List<StoreProductModels>()
            {
                new StoreProductModels{ItemId = 1, ItemName = "Power Drill", ItemPrice = 5.00},
                new StoreProductModels{ItemId = 2, ItemName = "Screwdriver", ItemPrice = 6.00},
                new StoreProductModels{ItemId = 3, ItemName = "Power Saw", ItemPrice = 7.00},
                new StoreProductModels{ItemId = 4, ItemName = "Jack Hammer", ItemPrice = 8.00}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

        }
    }
}