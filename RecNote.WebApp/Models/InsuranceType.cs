using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecNote.WebApp.Models
{
    public class InsuranceType
    {
        [Key]
        public int InsuranceTypeId { get; set; }

        [Required]
        public string InsuranceDescription { get; set; }

    }
}