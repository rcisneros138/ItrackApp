using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITrack.Controllers
{
    public class DropDownListController : Controller
    {
        public ActionResult Index(ViewModel.Employees employeeslist)
        {
            List<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem(){ Value="1", Text="ActionScript"},
                new SelectListItem(){ Value="2", Text="AppleScript"},
                new SelectListItem(){ Value="3", Text="Asp"},
                new SelectListItem(){ Value="4", Text="BASIC"},
                new SelectListItem(){ Value="5", Text="C"},
                new SelectListItem(){ Value="6", Text="C++"},
            };


            employeeslist = new ViewModel.Employees();
            employeeslist.employees = new SelectList(list, "Value", "Text");


            return View(employeeslist);
        }

        // GET: DropDownList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DropDownList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DropDownList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DropDownList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DropDownList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DropDownList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DropDownList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
