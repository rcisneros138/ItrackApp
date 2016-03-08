using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ITrack.Models
{
    public class ITrackDB : DbContext
    {
        public ITrackDB() : base("DefaultConnection")
        {
            
        }
  

        public System.Data.Entity.DbSet<ITrack.Models.Tickets> Tickets { get; set; }

        public System.Data.Entity.DbSet<ITrack.Models.Companies> Companies { get; set; }

        public System.Data.Entity.DbSet<ITrack.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<ITrack.Models.Tracker> Trackers { get; set; }

        public System.Data.Entity.DbSet<ITrack.Models.Inventory> Inventories { get; set; }
    }
}