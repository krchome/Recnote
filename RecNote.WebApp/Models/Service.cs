using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;


namespace RecNote.WebApp.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        public int ServiceTypeId { get;  set; }

        public   ServiceType servicetype { get; set; }
        //public IEnumerable<SelectListItem> UserRoles { get; set; }

        public IEnumerable<SelectListItem> ServiceDescription { get; set; }

        public IEnumerable<SelectListItem> ServiceDescriptionEditView { get; set; }

        public string TypeOfService { get; set; }
        public string ApplicationUser_Id { get; set; }
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public float InvoiceAmount { get; set; }

        [DataType(DataType.Date)]
        public string InvoiceDate { get; set; }

        public string PayeeBank { get; set; }

        public string PaymentMethod { get; set; }

        public IQueryable<ServiceType> GetServiceType()
        {
            //Models.Service type = new Service();

            var db = new RecNote.WebApp.Models.ApplicationDbContext();
            IQueryable<ServiceType> query = db.ServiceTypes;
            return query;
        }

       
    }
}