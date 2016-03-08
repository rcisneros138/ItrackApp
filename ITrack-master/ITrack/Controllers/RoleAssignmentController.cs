using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITrack.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace ITrack.Controllers
{
    public class RoleAssignmentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        RoleChange usersDb = new RoleChange();

        // GET: RoleAssignment
        [HttpGet]
        public ActionResult Index()
        {

           
            return View(GetAllUrsersAndRolls());
        }
    
        
        [HttpPost]
        public ActionResult  Index(string selectedRole, string selectedEmployee)
        {

            AddToRole(selectedRole, selectedEmployee);
            return Redirect("RoleAssignment");
           
        }

        public void AddToRole(string role, string employee)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = UserManager.FindByName(employee);
            var userRoles =  user.Roles.ToList();
           
            //user.Roles.Remove(roles);
            foreach (var Role in userRoles)
            {
               var roleName = roleManager.FindById(Role.RoleId);
               UserManager.RemoveFromRole(user.Id, roleName.Name);
            }

            UserManager.AddToRole(user.Id, role);
            
        }

        public RoleChange GetAllUrsersAndRolls()
        {
            var Model = new RoleChange
            {
                Users = context.Users.Select(x => new SelectListItem
                {
                    Value = x.UserName,
                    Text = x.UserName
                }),
                Roles = context.Roles.Select(x => new SelectListItem
                {
                    Value = x.Name,
                    Text = x.Name
                })
            };
            return Model;
        }
    }
    
}