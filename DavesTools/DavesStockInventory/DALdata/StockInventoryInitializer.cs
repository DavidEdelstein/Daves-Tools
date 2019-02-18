using DavesStockInventory.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace DavesStockInventory.DALdata
{
    internal class StockInventoryInitializer : CreateDatabaseIfNotExists<StockInventoryDbContext>
    {
        protected override void Seed(StockInventoryDbContext context)
        {
            var stock = new List<StockInventory>()
            {
                new StockInventory{ID = 1, Quantity = 3},
                new StockInventory{ID = 2, Quantity = 3},
                new StockInventory{ID = 3, Quantity = 3},
                new StockInventory{ID = 4, Quantity = 3}
            };

            context.Stock.AddRange(stock);
            context.SaveChanges();
        }
    }
}