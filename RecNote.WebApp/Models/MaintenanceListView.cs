//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecNote.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaintenanceListView
    {
        public int MaintenanceTypeId { get; set; }
        public int MaintenanceId { get; set; }
        public string ApplicationUser_Id { get; set; }
        public string DetailsOfWork { get; set; }
        public float InvoiceAmount { get; set; }
        public string InvoiceDetails { get; set; }
        public string Provider { get; set; }
        public string Comments { get; set; }
        public string DateDone { get; set; }
        public string DateDue { get; set; }
        public string TypeOfMaintenance { get; set; }
        public string MaintenanceDescription { get; set; }
    }
}