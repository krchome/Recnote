using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecNote.WebApp.Controllers
{
    public class LegalController : Controller
    {
        // GET: Legal
        [AllowAnonymous]
        public ActionResult TermsAndConditions()
        {
            return View();
        }
    }
}