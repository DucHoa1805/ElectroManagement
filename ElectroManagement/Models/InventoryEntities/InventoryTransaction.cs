using System;

namespace ElectroManagement.Models.InventoryEntities
{
    public class InventoryTransaction
    {
        public int TransactionID { get; set; }
        public int VariantID { get; set; }
        public int? ChangeQuantity { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
