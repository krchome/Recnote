using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace RecNote.WebApp.Models
{
    public class MaintenanceType
    {
        [Key]
        public int MaintenanceTypeId { get; set; }

         [Required()]
        public string MaintenanceDescription { get; set; }
    }
}