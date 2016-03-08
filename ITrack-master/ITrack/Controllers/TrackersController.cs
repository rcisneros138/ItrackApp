using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITrack.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using System.Threading.Tasks;


namespace ITrack.Controllers
{
    public class TrackersController : Controller
    {
        private ITrackDB db = new ITrackDB();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Trackers
        public ActionResult Index()
        {
            ViewResult result;
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                List<Tracker> listOfTrackers = new List<Tracker>();

                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                foreach (var tracks in db.Trackers)
                {
                    if (tracks.Company == userCompany)
                    {
                        listOfTrackers.Add(tracks);
                    }
                    else
                    {
                        result = View();
                    }
                }
                result = View(listOfTrackers);
                return result;
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }
        
        // GET: Trackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // GET: Trackers/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                ApplicationDbContext context = new ApplicationDbContext();
                List<ApplicationUser> AllDBUsers = context.Users.ToList();
                List<ApplicationUser> companyUsers = new List<ApplicationUser>();
                foreach (var user in AllDBUsers)
                {
                    if(user.Company == userCompany)
                    {
                        companyUsers.Add(user);
                    }
                }
                ViewBag.CompanyName = userCompany;
                ViewBag.UserList = companyUsers;
                return View();
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }


        //public ActionResult ShowAllNames()
        //{
        //    var users = Membership.GetAllUsers();

        //    return View(users);
        //}


        // POST: Trackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TimeOut,TicketID,Details,Location,Employee,ReturnDate,Company")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Trackers.Add(tracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tracker);
        }

        
        // GET: Trackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        public MembershipUserCollection ShowAllUsers()
        {
            var users = Membership.GetAllUsers();
            //SelectList listOfUsers = new SelectList(users);
            return users; 
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TimeOut,TicketID,Details,Location,Employee,ReturnDate,Company")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tracker);
        }

        // GET: Trackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // POST: Trackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tracker tracker = db.Trackers.Find(id);
            db.Trackers.Remove(tracker);
            db.SaveChanges();
            return RedirectToAction("Index");
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
