using System;
using System.Security.Cryptography;
using System.Text;

namespace ElectroManagement.Helpers
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Hàm băm mật khẩu sử dụng thuật toán SHA256
        /// </summary>
        /// <param name="password">Mật khẩu gốc (Plain text)</param>
        /// <returns>Chuỗi mật khẩu đã được băm</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển chuỗi thành mảng byte và tính toán mã băm
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển mảng byte ngược lại thành chuỗi Hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}