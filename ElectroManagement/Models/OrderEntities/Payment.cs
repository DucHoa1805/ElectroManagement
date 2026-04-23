using System;

namespace ElectroManagement.Models.OrderEntities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } // "Tiền mặt", "Chuyển khoản"
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}