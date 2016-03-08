using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITrack.Models;

namespace ITrack.Controllers
{
    public class TrackersController : Controller
    {
        private ITrackDB db = new ITrackDB();

        // GET: Trackers
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Trackers.ToList());
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
                return View();
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TimeOut,TicketID,Details,Location,Employee,ReturnDate")] Tracker tracker)
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

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TimeOut,Location,Employee,ReturnDate")] Tracker tracker)
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
