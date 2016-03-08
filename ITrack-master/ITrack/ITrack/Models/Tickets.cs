using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ITrack.Models
{
    public class Tickets 
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public string Company { get; set; }
        public string Details { get; set; }
        public string TimeRequest { get; set; }
        public string Priority { get; set; }
        public string Employee { get; set; }
        public bool Completed { get; set; }
        public string TimeCompleted { get; set; }
    }
}