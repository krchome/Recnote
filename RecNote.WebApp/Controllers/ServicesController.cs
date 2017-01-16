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
using Recnote.WebApp.Models;
//using Recnote.WebApp.Models;


namespace RecNote.WebApp.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Entities _db;

        public ServicesController()
        {
            _db = new Entities();
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

        // GET: Services
        //public ActionResult Index()
        //{
        //    ViewBag.UserID = User.Identity.GetUserId();
        //    ViewData.Model = _db.IndexListViews.ToList();

        //    return View();
        //    //return View(service);
        //}

        public ViewResult Index()
        {
            var servicetypes = new SelectList(db.ServiceTypes.Select(r=>r.ServiceTypeDescription).Distinct().ToList());
            ViewBag.UserID = User.Identity.GetUserId();
            ViewBag.Servicetypes = servicetypes;
            return View();
        }

        [HttpGet]
        public PartialViewResult ServicesByServiceTypesPartial(string ServiceType)
        {
            //var query = db.ServiceTypes.Where(r=>r.ServiceTypeDescription == ServiceTypeId)

           // var description = from ServiceTypeId in db.ServiceTypes where db.ServiceTypes.ServiceTypeDescription == ServiceTypeId select ServiceTypeId;
            string UserId = User.Identity.GetUserId();
            int _ServiceTypeId = 0;
            switch (ServiceType)
            {
                case "Electricity":
                    _ServiceTypeId = 1;
                    break;
                case "Telecom":
                    _ServiceTypeId = 2;
                    break;
                case "Water":
                    _ServiceTypeId = 3;
                    break;

            }
            return PartialView("ServicesByServiceTypesPartial",
                db.Services.Where(r => (r.ServiceTypeId == _ServiceTypeId) && (r.ApplicationUser_Id == UserId)).OrderByDescending(r => r.InvoiceDate).ToList());
                   
        }

        private IEnumerable<SelectListItem> GetTypeOfService()
        {
            var serviceTypes = new Service();
            var roles = serviceTypes.GetServiceType()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ServiceTypeId.ToString(),
                                    Text = x.ServiceTypeDescription
                                });

            return new SelectList(roles, "Value", "Text");
        }

        private string GetDescription(int? id)
        {
          
            string type1 = "";
            var query = from c in db.Services
                        join a in db.ServiceTypes
                        on c.ServiceTypeId equals a.ServiceTypeId
                        where c.ServiceId == id
                        select new
                        {
                            type =  a.ServiceTypeDescription.ToString()

                        };

            foreach (var c in query)
             {
                type1 = c.type;
             }

            //return query.FirstOrDefault().ToString();
            return type1;

        }

        // Following code is being tested for Edit view 
        private IEnumerable<SelectListItem> GetDescriptionForEdit(int? id)
        {
            //string type1 = "";
            var query = from c in db.Services
                        join a in db.ServiceTypes
                        on c.ServiceTypeId equals a.ServiceTypeId
                        where c.ServiceId == id
                        select new
                        {
                            Value = a.ServiceTypeId.ToString(),
                            Text = a.ServiceTypeDescription.ToString()
                            

                        };

            return new SelectList(query, "Value", "Text");
        }


        Service FindService(int? id)
        {
            Service service = db.Services.Find(id);
            if (service == null || service.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return null;
            }
            return service;
        }
        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserID = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = FindService(id);

            if (service.TypeOfService == null)
            {

                service.TypeOfService = GetDescription(id);
               
            }

           // return View(model);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
           
            var model = new Service()
            {
                ServiceDescription = GetTypeOfService()
            };

            return View(model);
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,ServiceTypeId,AccountNumber,AccountName,Address,InvoiceAmount,InvoiceDate,PayeeBank,PaymentMethod")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.ApplicationUser_Id = User.Identity.GetUserId();
         //      service.servicetype = db.ServiceTypes.Find(service.servicetype.ServiceTypeId);
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            //old code 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = FindService(id);

            if (service.TypeOfService == null)
            {

                service.TypeOfService = GetDescription(id);

            }

            if (service == null)
            {
                return HttpNotFound();
            }
            //ServiceDescriptionEditView
            //==========Following block of code is being commented to try something new ========//

            var model = new Service()
            {
                ServiceDescriptionEditView = GetDescriptionForEdit(id),


            };


            service.ServiceDescriptionEditView = model.ServiceDescriptionEditView;
            return View(service);
          

           
        }

        private IEnumerable<SelectListItem> GetDataEditSelectList(int? id)
        {
            var model = _db.IndexListViews.ToList();

            var query = from a in _db.IndexListViews
                        //join a in db.ServiceTypes
                        //on c.ServiceTypeId equals a.ServiceTypeId
                        where a.ServiceId == id
                        select new
                        {
                            Value = a.ServiceTypeId.ToString(),
                            Text = a.ServiceTypeDescription.ToString()


                        };

            

            return new SelectList(query, "Value", "Text");
            //return ;
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceId,ServiceTypeId,ApplicationUser_Id,AccountNumber,AccountName,Address,InvoiceAmount,InvoiceDate,PayeeBank,PaymentMethod")] Service service)
        {
            if (service.ApplicationUser_Id != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {

             //   service.servicetype = db.ServiceTypes.Find(service.servicetype.ServiceTypeId);
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ServiceTypeId = new SelectList(scdb.ServiceTypes, "ServiceTypeId", "ServiceTypeDescription", service.ServiceTypeId);//new code
            return View(service);

        
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = FindService(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            if (service.TypeOfService == null)
            {

                service.TypeOfService = GetDescription(id);

            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = FindService(id);
            if (service.TypeOfService == null)
            {

                service.TypeOfService = GetDescription(id);

            }
            if (service == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Services.Remove(service);
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
