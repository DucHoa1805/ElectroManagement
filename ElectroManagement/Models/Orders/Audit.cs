using System;

namespace ElectroManagement.Models.Orders
{
    public class Audit
    {
        public int LogID { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; } // Hiển thị tên thay vì ID sau khi JOIN
        public string Action { get; set; }
        public string TableName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}