using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecNote.WebApp.Models
{
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }

        public int InsuranceTypeId { get; set; }

        public InsuranceType insurancetype { get; set; }

        public IEnumerable<SelectListItem> InsuranceDescription { get; set; }

        public IEnumerable<SelectListItem> InsuranceDescriptionEditView { get; set; }

        public string ApplicationUser_Id { get; set; }


        [Required]
        public string CustomerNumber { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        public string PolicyType { get; set; }

        [Required]
        public string InsuredName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public string PolicyStartDate { get; set; }

        [DataType(DataType.Date)]
        public string PolicyEndDate { get; set; }

        [DataType(DataType.Currency)]
        public float PremiumAmount { get; set; }
        
        [Required]
        public string PaymentType { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public string PayeeBank { get; set; }

        public string Comments { get; set; }












    }
}