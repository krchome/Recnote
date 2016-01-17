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
        public ActionResult Index()
        {
            ViewBag.UserID = User.Identity.GetUserId();
            ViewData.Model = _db.IndexListViews.ToList();

            return View();
            //return View(service);
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

            //foreach (var c in query)
            //{
            //    type1 = c.type;
            //}

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
            //List<SelectListItem> servicetypes = (from p in
            //                                         new Models.Service().GetServiceType().ToList()
            //                                     select new SelectListItem()
            //                                     {
            //                                         Value = p.ServiceTypeId.ToString(),
            //                                         Text = p.ServiceTypeDescription
            //                                     }).ToList();
            //ViewBag.ServiceTypeId = servicetypes;
            //return View();
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
           //ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "ServiceTypeId", "Service Type", service.ServiceTypeId);
         //  ViewData["ServiceTypeId"] = service;
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
            //======================================================//
            //var model = new EditIndexViewModel();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var model1 = new Service()
            //{
            //    ServiceDescription = GetDataEditSelectList(id)

            //};
           // var model = GetDataEditSelectList(id);
           // var model = new IndexListView()
           // {
             //   ServiceDescription = GetDataEditSelectList(id)
           // };
            //ViewData.Model = _db.IndexListViews.ToList();
            //return ViewData();
            //var model1 = new IndexListView();
            //model1.ServiceDescription = GetDataEditSelectList(id);
            ////model.Add(model1);

            //model = (_db.IndexListViews.ToList());
            //{
            //    ServiceDescription = GetDataEditSelectList(id);
            //}

            //var model = new IndexListView()
            //{
            //    ServiceDescription = GetDataEditSelectList(id)
            //};

            //var model = new  
            //{
            //    ServiceDescription = GetDataEditSelectList(id)
            //};
            //return View(model);
            
           // }

           
        }

        private IEnumerable<SelectListItem> GetDataEditSelectList(int? id)
        {
            var model = _db.IndexListViews.ToList();

            //if (id != null)
            //{
            //    model.Single(x => x.ServiceId == id);
            //    _db.IndexListViews.ToList().Select(x => new SelectListItem
            //    {
            //        Value = x.ServiceTypeId.ToString(),
            //        Text = x.ServiceTypeDescription
            //    });
            //}

            var query = from a in _db.IndexListViews
                        //join a in db.ServiceTypes
                        //on c.ServiceTypeId equals a.ServiceTypeId
                        where a.ServiceId == id
                        select new
                        {
                            Value = a.ServiceTypeId.ToString(),
                            Text = a.ServiceTypeDescription.ToString()


                        };

            //foreach (var c in query)
            //{
            //    type1 = c.type;
            //}

            //var serviceTypes = db.Services;
            //var roles = db.Services.
            //            Select(x =>
            //                    new SelectListItem
            //                    {
            //                        Value = x.ServiceTypeId.ToString(),
            //                        Text = x.ServiceDescription.ToString()
            //                    });

            

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

            //
        //    model.CandidatesList = serviceCandidate
        //.GetCandidates()
        //.Select(x => new SelectListItem
        //{
        //    Text = x.Nominative,
        //    Value = x.CandidateId.ToString()
        //});

        //    return View(model);
            //
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
