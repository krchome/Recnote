using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

         RecNote.WebApp.Models.MaintenanceEntities _db;

      

        [AllowAnonymous]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();

        }
         [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            //ViewBag.Message = "This is the services page. Here you will get all the links to the billing related information for resources such as electricity, telephone(internet), water";

            return View();
        }
    }
}