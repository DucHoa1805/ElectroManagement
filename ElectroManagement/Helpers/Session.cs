using System;
using ElectroManagement.Models.AuthEntities; // Nhớ using Model User của bạn

namespace ElectroManagement.Helpers
{
    public static class Session
    {
        // Lưu trữ thông tin người dùng đang đăng nhập hệ thống
        public static User CurrentUser { get; private set; }

        // Trả về true nếu đã có người đăng nhập
        public static bool IsLoggedIn => CurrentUser != null;

        /// <summary>
        /// Gọi hàm này khi đăng nhập thành công để lưu phiên làm việc
        /// </summary>
        public static void Login(User user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Gọi hàm này khi người dùng bấm Đăng xuất
        /// </summary>
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}