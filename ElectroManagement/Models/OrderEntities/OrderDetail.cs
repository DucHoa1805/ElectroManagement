namespace ElectroManagement.Models.OrderEntities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; } // Lưu tên hoặc ProductId tùy bạn thiết kế DB
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; } // Quantity * UnitPrice
    }
}