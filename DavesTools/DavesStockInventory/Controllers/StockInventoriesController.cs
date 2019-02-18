using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DavesStockInventory.DALdata;
using DavesStockInventory.Models;

namespace DavesStockInventory.Controllers
{
    public class StockInventoriesController : ApiController
    {
        private StockInventoryDbContext db = new StockInventoryDbContext();

        // GET: api/StockInventories
        public IQueryable<StockInventory> GetStock()
        {
            return db.Stock;
        }

        // GET: api/StockInventories/5
        [ResponseType(typeof(StockInventory))]
        public IHttpActionResult GetStockInventory(int id)
        {
            StockInventory stockInventory = db.Stock.Find(id);
            if (stockInventory == null)
            {
                return NotFound();
            }

            return Ok(stockInventory.Quantity);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockInventoryExists(int id)
        {
            return db.Stock.Count(e => e.ID == id) > 0;
        }
    }
}