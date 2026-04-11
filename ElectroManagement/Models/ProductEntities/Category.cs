using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroManagement.Models.ProductEntities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int IsDeleted { get; set; } // Nếu bạn dùng xóa mềm
    }
}
