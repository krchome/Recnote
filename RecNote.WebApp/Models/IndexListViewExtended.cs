using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecNote.WebApp.Models
{
    public partial class IndexListView
    {
        public IEnumerable<SelectListItem> ServiceDescription { get; set; }
    }
}