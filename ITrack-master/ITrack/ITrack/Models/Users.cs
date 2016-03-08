using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITrack.Models
{
    public class Users 
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}