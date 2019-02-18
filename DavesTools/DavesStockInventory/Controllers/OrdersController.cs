using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DavesStockInventory.DALdata;
using DavesStockInventory.Models;

namespace DavesStockInventory.Controllers
{
    public class OrdersController : ApiController
    {
        private StockInventoryDbContext db = new StockInventoryDbContext();

       
        // POST: api/Orders
        [ResponseType(typeof(StockInventory))]
        public IHttpActionResult PostStockInventory(StockInventory stockInventory)
        {
            StockInventory DbStockInventory = db.Stock.Find(stockInventory.ID);
            //
            DbStockInventory.Quantity = DbStockInventory.Quantity - 1; 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = DbStockInventory.ID }, DbStockInventory);
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