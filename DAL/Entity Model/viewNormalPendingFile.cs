//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entity_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class viewNormalPendingFile
    {
        public System.Guid ID { get; set; }
        public byte Mode { get; set; }
        public string Truck { get; set; }
        public string ProductCode { get; set; }
        public string SupplierName { get; set; }
        public string TransporterCode { get; set; }
        public string ChallanNumber { get; set; }
        public System.DateTime ChallanDate { get; set; }
        public decimal ChallanWeight { get; set; }
        public byte ChallanWeightUnit { get; set; }
        public string Miscellaneous { get; set; }
        public string DeliveryNoteN { get; set; }
        public System.DateTime DateIn { get; set; }
        public System.DateTime DateOut { get; set; }
        public System.TimeSpan TimeIn { get; set; }
        public System.TimeSpan TimeOut { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public byte IsPending { get; set; }
        public decimal NetWeight { get; set; }
        public string ProdInOut { get; set; }
    }
}
