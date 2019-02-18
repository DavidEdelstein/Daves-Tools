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

        // PUT: api/StockInventories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStockInventory(int id, StockInventory stockInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockInventory.ID)
            {
                return BadRequest();
            }

            db.Entry(stockInventory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockInventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StockInventories
        [ResponseType(typeof(StockInventory))]
        public IHttpActionResult PostStockInventory(StockInventory stockInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stock.Add(stockInventory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stockInventory.ID }, stockInventory);
        }

        // DELETE: api/StockInventories/5
        [ResponseType(typeof(StockInventory))]
        public IHttpActionResult DeleteStockInventory(int id)
        {
            StockInventory stockInventory = db.Stock.Find(id);
            if (stockInventory == null)
            {
                return NotFound();
            }

            db.Stock.Remove(stockInventory);
            db.SaveChanges();

            return Ok(stockInventory);
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