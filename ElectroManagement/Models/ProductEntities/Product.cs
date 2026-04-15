using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroManagement.Models.ProductEntities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; } // Lưu ID để Thêm/Sửa
        public int BrandID { get; set; }    // Lưu ID để Thêm/Sửa
        public string Description { get; set; }

    }
}
