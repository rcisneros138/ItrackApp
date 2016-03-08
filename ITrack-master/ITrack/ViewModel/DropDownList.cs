using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace ITrack.ViewModel
{
    public class Employees
    {
        public int selectedId { get; set; }

        public System.Web.Mvc.SelectList employees;
    }
}