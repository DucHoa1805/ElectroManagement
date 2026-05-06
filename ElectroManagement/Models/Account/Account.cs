using System;

namespace ElectroManagement.Models
{
    public class Account
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}