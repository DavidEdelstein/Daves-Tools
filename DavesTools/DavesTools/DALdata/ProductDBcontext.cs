using DavesTools.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DavesTools.DALdata
{
    public class ProductDBcontext : DbContext
    {
        public ProductDBcontext() : base ("ProductContext")
        {
            Database.SetInitializer(new ProductDbInitializer());
        }

        public DbSet<StoreProductModels> Products { get; set; }
    }
}