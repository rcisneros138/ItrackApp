using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ITrack.Models
{
    public class Tracker 
    {
        public int ID { get; set; }
        public string TicketID { get; set; }
        public string Details { get; set; }
        public string TimeOut { get; set; }
        public string Location { get; set; }
        public string Employee { get; set; }
        public string ReturnDate { get; set; }
    }
}