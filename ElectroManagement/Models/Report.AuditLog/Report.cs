using System;

namespace ElectroManagement.Models.Report.AuditLog
{
    public class RevenueReport
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
    }
}