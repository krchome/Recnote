using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using Recnote.WebApp.Models;
using RecNote.WebApp.Models;
//using Recnote.WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Recnote.WebApp.Models;

namespace RecNote.WebApp.Controllers
{
    //changes already made for v2 to include user data access
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // new code to include profile data access to logged in users
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Contacts
        public ActionResult Index()
        {
            // get the id of logged in user
            ViewBag.UserID = User.Identity.GetUserId();
            return View(db.Contacts.ToList());
        }

        Contact FindContact(int? id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null || contact.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return null;
            }
            return contact;
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {

            ViewBag.UserID = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recnote.WebApp.Models.Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        
        public ActionResult Create()
        {
            return View(new Contact
            {

                Name = "Amit Ghosh",
                Address = "123 Great South rd",
                City = "Auckland",
                Suburb = "Papatoetoe",
                PostCode = "2025",
                Email = "am@example.com",
                Phone = "2788801",
                Mobile = "0210781102"
            });
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ContactId,Name,Address,City,Suburb,PostCode,Email,Phone,Mobile")] Recnote.WebApp.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.ApplicationUser_Id = User.Identity.GetUserId();
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recnote.WebApp.Models.Contact contact = FindContact(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "ContactId,Name,Address,City,Suburb,PostCode,Email,Phone,Mobile,ApplicationUser_Id")] Recnote.WebApp.Models.Contact contact)
        {

            if (contact.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recnote.WebApp.Models.Contact contact = FindContact(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Recnote.WebApp.Models.Contact contact = FindContact(id);
            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Contacts.Remove(contact);
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
