using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecNote.WebApp.Models;

namespace RecNote.WebApp.Controllers
{
    public class MaintenancesTestController : Controller
    {
        private Entities db = new Entities();

        // GET: MaintenancesTest
        public ActionResult Index()
        {
            var maintenances = db.Maintenances.Include(m => m.maintenancetype);
            return View(maintenances.ToList());
        }

        // GET: MaintenancesTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // GET: MaintenancesTest/Create
        public ActionResult Create()
        {
            ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription");
            return View();
        }

        // POST: MaintenancesTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintenanceId,MaintenanceTypeId,ApplicationUser_Id,DetailsOfWork,InvoiceAmount,InvoiceDetails,Provider,Comments,DateDone,DateDue")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            return View(maintenance);
        }

        // GET: MaintenancesTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            return View(maintenance);
        }

        // POST: MaintenancesTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintenanceId,MaintenanceTypeId,ApplicationUser_Id,DetailsOfWork,InvoiceAmount,InvoiceDetails,Provider,Comments,DateDone,DateDue")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            return View(maintenance);
        }

        // GET: MaintenancesTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // POST: MaintenancesTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            db.Maintenances.Remove(maintenance);
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
