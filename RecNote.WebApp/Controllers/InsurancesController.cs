using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecNote.WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RecNote.WebApp.Controllers
{
    public class InsurancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insurances
        public ActionResult Index()
        {
            var insurances = db.Insurances.Include(i => i.insurancetype);
            return View(insurances.ToList());
        }

        // GET: Insurances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // GET: Insurances/Create
        public ActionResult Create()
        {
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceDescription");
            return View();
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsuranceId,InsuranceTypeId,CustomerNumber,PolicyNumber,PolicyType,InsuredName,PolicyStartDate,PolicyEndDate,PremiumAmount,PaymentType,PaymentMethod,PayeeBank,Comments")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                insurance.ApplicationUser_Id = User.Identity.GetUserId();
                db.Insurances.Add(insurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceDescription", insurance.InsuranceTypeId);
            return View(insurance);
        }

        // GET: Insurances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceDescription", insurance.InsuranceTypeId);
            return View(insurance);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsuranceId,InsuranceTypeId,CustomerNumber,PolicyNumber,PolicyType,InsuredName,PolicyStartDate,PolicyEndDate,PremiumAmount,PaymentType,PaymentMethod,PayeeBank,Comments")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceDescription", insurance.InsuranceTypeId);
            return View(insurance);
        }

        // GET: Insurances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance insurance = db.Insurances.Find(id);
            db.Insurances.Remove(insurance);
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
