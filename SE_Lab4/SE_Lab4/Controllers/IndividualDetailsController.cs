using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE_Lab4.Controllers
{
    public class IndividualDetailsController : Controller
    {
        // GET: IndividualDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndividualDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndividualDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndividualDetails/Create
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

        // GET: IndividualDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndividualDetails/Edit/5
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

        // GET: IndividualDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndividualDetails/Delete/5
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
