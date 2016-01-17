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
    public class MaintenancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Entities _db;

        RecNote.WebApp.Models.MaintenanceEntities _db;

        public MaintenancesController()
        {
            _db = new MaintenanceEntities();
        }

      //  private ServiceContext scdb = new ServiceContext();

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

        // GET: Maintenances
        public ActionResult Index()
        {
            //var maintenances = db.Maintenances.Include(m => m.maintenancetype);
            //return View(maintenances.ToList());
            ViewBag.UserID = User.Identity.GetUserId();
            //ViewData.Model = _db.IndexListViews.ToList();
            ViewData.Model = _db.MaintenanceListViews.ToList();

            return View();
        }

        private IEnumerable<SelectListItem> GetTypeOfMaintenance()
        {
            var maintenanceTypes = new Maintenance();
            var roles = maintenanceTypes.GetMaintenanceType()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.MaintenanceTypeId.ToString(),
                                    Text = x.MaintenanceDescription
                                });

            return new SelectList(roles, "Value", "Text");
        }

        private string GetDescription(int? id)
        {

            string type1 = "";
            var query = from c in db.Maintenances
                        join a in db.MaintenanceTypes
                        on c.MaintenanceTypeId equals a.MaintenanceTypeId
                        where c.MaintenanceId == id
                        select new
                        {
                            type = a.MaintenanceDescription.ToString()

                        };

            foreach (var c in query)
            {
                type1 = c.type;
            }

            //return query.FirstOrDefault().ToString();
            return type1;

        }

        private IEnumerable<SelectListItem> GetDescriptionForEdit(int? id)
        {
            //string type1 = "";
            var query = from c in db.Maintenances
                        join a in db.MaintenanceTypes
                        on c.MaintenanceTypeId equals a.MaintenanceTypeId
                        where c.MaintenanceId == id
                        select new
                        {
                            Value = a.MaintenanceTypeId.ToString(),
                            Text = a.MaintenanceDescription.ToString()


                        };

            //foreach (var c in query)
            //{
            //    type1 = c.type;
            //}

            return new SelectList(query, "Value", "Text");
        }

        Maintenance FindMaintenance(int? id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null || maintenance.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return null;
            }
            return maintenance;
        }
        // GET: Maintenances/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserID = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = FindMaintenance(id);

            if(maintenance.TypeOfMaintenance == null)
            {
                maintenance.TypeOfMaintenance = GetDescription(id);
            }
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // GET: Maintenances/Create
        public ActionResult Create()
        {
            //ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription");
            //return View();
            var model = new Maintenance()
            {
                MaintenanceDescription = GetTypeOfMaintenance()
            };

            return View(model);
        }

        // POST: Maintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintenanceId,MaintenanceTypeId,ApplicationUser_Id,DetailsOfWork,InvoiceAmount,InvoiceDetails,Provider,Comments,DateDone,DateDue")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                maintenance.ApplicationUser_Id = User.Identity.GetUserId();
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            return View(maintenance);
        }

        // GET: Maintenances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = FindMaintenance(id);

            if(maintenance.TypeOfMaintenance == null)
            {
                maintenance.TypeOfMaintenance = GetDescription(id);
            }
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            //return View(maintenance);

            var model = new Maintenance()
            {
                //MaintenanceDescriptionEditView = GetDescriptionForEdit(id),
                TypeOfMaintenance = _db.MaintenanceListViews.Where(x => x.MaintenanceTypeId == id).ToString() 

            };


           // maintenance.MaintenanceDescriptionEditView = model.MaintenanceDescriptionEditView;
            maintenance.MaintenanceDescription = model.MaintenanceDescription;
            return View(maintenance);
        }

        // POST: Maintenances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintenanceId,MaintenanceTypeId,ApplicationUser_Id,DetailsOfWork,InvoiceAmount,InvoiceDetails,Provider,Comments,DateDone,DateDue")] Maintenance maintenance)
        {
            if (maintenance.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.MaintenanceTypeId = new SelectList(db.MaintenanceTypes, "MaintenanceTypeId", "MaintenanceDescription", maintenance.MaintenanceTypeId);
            return View(maintenance);
        }

        // GET: Maintenances/Delete/5
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

            if (maintenance.TypeOfMaintenance == null)
            {
                maintenance.TypeOfMaintenance = GetDescription(id);
            }
            return View(maintenance);
        }

        // POST: Maintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintenance maintenance = FindMaintenance(id);
            if (maintenance.TypeOfMaintenance == null)
            {
                maintenance.TypeOfMaintenance = GetDescription(id);
            }
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
