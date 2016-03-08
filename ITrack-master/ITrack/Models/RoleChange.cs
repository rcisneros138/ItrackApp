using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ITrack.Models
{
    public class RoleChange
    {
        
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> Roles  { get; set; }

        public string selectedRole { get; set; }
        public string selectedEmployee { get; set; }


    }
}