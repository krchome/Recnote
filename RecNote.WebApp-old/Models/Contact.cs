using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Recnote.WebApp.Models
{
    //changes already made for v2 to include user data access
    public class Contact
    {
        public int ContactId { get; set; }

        //Included application user id for part 2 
        public string ApplicationUser_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}