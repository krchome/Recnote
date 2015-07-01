using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace RecNote.WebApp.Models
{
    public class ServiceTypeViewModels
    {
        // Display Attribute will appear in the Html.LabelFor
        [Display(Name = "Service Type")]
        public int ServiceTypeId { get; set; }

        public IEnumerable<SelectListItem> ServiceDescription { get; set; }

    }
}