using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DavesTools.DALdata;
using DavesTools.Models;

namespace DavesTools.Controllers
{
    public class StoreProductController : Controller
    {
        private ProductDBcontext db = new ProductDBcontext();

        // GET: StoreProduct
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: StoreProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreProductModels storeProductModels = db.Products.Find(id);
            if (storeProductModels == null)
            {
                return HttpNotFound();
            }
            return View(storeProductModels);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
