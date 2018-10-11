using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebTemp.Models;
using System.Web.Routing;
namespace WebTemp.Controllers
{
    public class PersonController : Controller
    {
        
        PhoneBookDbEntities db = new PhoneBookDbEntities();
        // GET: Person
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var cus = db.People.Single(c => c.PersonId == id);
            if (cus == null)
                return HttpNotFound();
            return View(cus);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person p)
        {
            if(ModelState.IsValid)
            {
                LoggedUser.id = User.Identity;
                var currentUser=LoggedUser.id.GetUserId();
                var addedBy=db.AspNetUsers.Single(c => c.Id == currentUser);
                p.AddedBy = addedBy.Id;
                p.AddedOn = DateTime.Now;
                p.UpdateOn = DateTime.Now;
                db.People.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var cus = db.People.Single(c => c.PersonId == id);
            if (cus == null)
                return HttpNotFound();
            return View(cus);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            try
            {
                // TODO: Add update logic here
                var personUpdate = db.People.Single(c => c.PersonId == id);
                personUpdate.UpdateOn = DateTime.Now;
                TryUpdateModel(personUpdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var cus = db.People.Single(c => c.PersonId == id);
            var deleteAllContactsFirst = db.Contacts.Where(x => x.PersonId == id).ToList();

            totalContacts t = new totalContacts();
            t.CurrsentPerson =cus;
            t.Total = deleteAllContactsFirst.Count();
            if (t == null)
                return HttpNotFound();
            return View(t);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person p)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add delete logic here
                var deleteAllContactsFirst = db.Contacts.Where(x => x.PersonId == id).ToList();
                foreach(var con in deleteAllContactsFirst)
                {
                    db.Contacts.Remove(con);
                    db.SaveChanges(); 
                }
                var deletePerson = db.People.Single(c => c.PersonId == id);
                db.People.Remove(deletePerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ViewContacts(int id)
        {
            List<Contact> cl = db.Contacts.Where(x => x.PersonId == id).ToList();
            if(cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);
        }
        
        public ActionResult AddContacts(int id,Contact c)
        {
            try
            {
                var person = db.People.Single(o => o.PersonId == id);
                c.Person = person;
                c.PersonId = id;
                db.Contacts.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteContact(int id)
        {
            var deleteContact = db.Contacts.Single(c => c.ContactId == id);
            db.Contacts.Remove(deleteContact);
            db.SaveChanges();
            return View(deleteContact);
        }
        public ActionResult EditContact(int id)
        {
            var forEdit = db.Contacts.Single(c => c.ContactId == id);
            return View(forEdit);
        }
        [HttpPost]
        public ActionResult EditContact(int id ,Contact con)
        {
            
            var forEdit = db.Contacts.Single(c => c.ContactId == id);
            TryUpdateModel(forEdit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
