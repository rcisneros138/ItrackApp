using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITrack.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ITrack.Controllers
{
    public class InventoriesController : Controller
    {
        private ITrackDB db = new ITrackDB();


        // GET: Inventories
        public ActionResult Index()
        {
            ViewResult result;
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                List<Inventory> ListOfCompanyItems = new List<Inventory>();

                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                foreach (var items in db.Inventories)
                {
                    if (items.Company == userCompany)
                    {
                        ListOfCompanyItems.Add(items);
                    }
                    else
                    {
                        result = View();
                    }
                }
                result = View(ListOfCompanyItems);
                return result;
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // GET: Inventories
        public ActionResult Catalog()
        {
            ViewResult result;
            if (User.Identity.IsAuthenticated)
            {
                var UserID = User.Identity.GetUserId();
                List<Inventory> ListOfCompanyItems = new List<Inventory>();

                string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
                foreach (var items in db.Inventories)
                {
                    if (items.Company == userCompany)
                    {
                        ListOfCompanyItems.Add(items);
                    }
                    else
                    {
                        result = View();
                    }
                }
                result = View(ListOfCompanyItems);
                return result;
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            var UserID = User.Identity.GetUserId();
            string userCompany = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserID).Company;
            ViewBag.CompanyName = userCompany;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }

            else
            {
                return Redirect("~/Account/Login");
            }
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,SKU,Company,Home,Description,Price")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,SKU,Company,Home,Description,Price")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
