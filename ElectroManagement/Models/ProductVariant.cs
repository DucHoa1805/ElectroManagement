using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroManagement.Models
{
    public class ProductVariant
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string Color { get; set; }
        public string Storage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
