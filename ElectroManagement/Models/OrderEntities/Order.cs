using System;

namespace ElectroManagement.Models.OrderEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } // Ví dụ: "Pending", "Completed", "Cancelled"
    }
}