using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroManagement.Models.AuthEntities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
        public bool? IsActive { get; set; }

        // Cột bổ sung không có trong bảng Users, nhưng lấy từ JOIN với bảng Roles để tiện dùng
        public string RoleName { get; set; }
    }
}