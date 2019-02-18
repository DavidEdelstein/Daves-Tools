using DavesStockInventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DavesStockInventory.DALdata
{
    public class StockInventoryDbContext : DbContext
    {
        public StockInventoryDbContext() : base ("InventoryContext")
        {
            Database.SetInitializer(new StockInventoryInitializer());
        }

        public DbSet<StockInventory> Stock { get; set; }
    }
}