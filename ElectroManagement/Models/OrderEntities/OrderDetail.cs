namespace ElectroManagement.Models.OrderEntities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int VariantID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        // Thêm property để bind tồn kho
        public int Stock { get; set; }
    }
}
