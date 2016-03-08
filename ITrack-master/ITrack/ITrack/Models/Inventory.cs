using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ITrack.Models
{
    public class Inventory 
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Company { get; set; }
        public bool Home { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}