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

namespace ITrack.Controllers
{
    public class TicketsController : Controller
    {
        private ITrackDB db = new ITrackDB();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                ViewBag.CompanyName = userCompany;
                List<Tickets> CompanyTickets = new List<Tickets>();
                return View(db.Tickets.ToList());
            }
            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            var UserID = User.Identity.GetUserId();
            string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CompanyName = userCompany;
                return View();
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        public ActionResult ViewOpenTickets()
        {
            ViewResult result;
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                List<Tickets> listOfTickets = new List<Tickets>();
               
                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                foreach (var ticket in db.Tickets)
                {
                    if (ticket.Company == userCompany)
                    {
                        listOfTickets.Add(ticket);
                    }
                    else
                    {
                        result = View();
                    }
                }
                result = View(listOfTickets);
                return result;
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Client,Company,Details,TimeRequest,Priority,Employee,Completed,TimeCompleted")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("ViewOpenTickets");
            }

            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Client,Company,Details,TimeRequest,Priority,Employee,Completed,TimeCompleted")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewOpenTickets");
            }
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            db.Tickets.Remove(tickets);
            db.SaveChanges();
            return RedirectToAction("ViewOpenTickets");
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
