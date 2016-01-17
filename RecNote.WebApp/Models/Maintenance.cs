using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace RecNote.WebApp.Models
{
    public class Maintenance
    {
        [Key]
        public int MaintenanceId { get; set; }

        public int MaintenanceTypeId { get; set; }

        public MaintenanceType maintenancetype { get; set; }

        public IEnumerable<SelectListItem> MaintenanceDescription { get; set; }

        public IEnumerable<SelectListItem> MaintenanceDescriptionEditView { get; set; }

        public string ApplicationUser_Id { get; set; }

        public string TypeOfMaintenance { get; set; }
         
        [Required()]
        public string DetailsOfWork { get; set; }

         [Required()]
        [DataType(DataType.Currency)]
        public float InvoiceAmount { get; set; }

         
        public string InvoiceDetails { get; set; }

         [Required()]
        public string Provider { get; set; }

        public string Comments { get; set; }

        [Required()]
        [DataType(DataType.Date)]
        public string DateDone { get; set; }

        [DataType(DataType.Date)]
        public string DateDue { get; set; }

        public IQueryable<MaintenanceType> GetMaintenanceType()
        {
            //Models.Service type = new Service();

            var db = new RecNote.WebApp.Models.ApplicationDbContext();
            IQueryable<MaintenanceType> query = db.MaintenanceTypes;
            return query;
        }



















    }
}