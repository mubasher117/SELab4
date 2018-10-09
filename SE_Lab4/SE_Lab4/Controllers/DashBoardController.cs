using SE_Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE_Lab4.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View(CreateDashboard());
        }

        // GET: DashBoard/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities phoneBookDbEntities = new PhoneBookDbEntities();
            ViewBag.count = phoneBookDbEntities.AspNetUsers.Count();
            return View();
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
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

        // GET: DashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Edit/5
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

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
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
        public Dashboard CreateDashboard()
        {
            PhoneBookDbEntities phoneBookDbEntities = new PhoneBookDbEntities();
            Dashboard dashboard = Dashboard.GetInstance();
            dashboard.AddedPersons = phoneBookDbEntities.People.Count();
            foreach (Person person in phoneBookDbEntities.People)
            {
                if ((DateTime.Today - person.UpdateOn.Value).TotalDays >0 &&(DateTime.Today - person.UpdateOn.Value  ).TotalDays <= 7 )
                {
                    dashboard.Updated_People.Add(person);
                }
            }
            return dashboard;
        }
    }
}
