using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace RecNote.WebApp.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }

        public string ServiceTypeDescription { get; set; }

        public virtual ICollection<Service> Services { get; set; }

         //public IQueryable<ServiceType> GetServiceType()
         //   {
         //       Models.ServiceType type = new ServiceType();
         //       return type.GetServiceType();
         //   }
    }

   
}