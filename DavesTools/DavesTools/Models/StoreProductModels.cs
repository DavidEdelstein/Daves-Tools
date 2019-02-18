using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DavesTools.Models
{
    public class StoreProductModels
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
    }
}