namespace RecNote.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   // using System.Web.WebPages.Html;
    using System.Web.Mvc;

    public  class EditIndexViewModel
    {


        public IEnumerable<SelectListItem> ServiceType { get; set; }
        public Service service { get; set; }

        public IndexListView indexlistview { get; set; }




    }
}