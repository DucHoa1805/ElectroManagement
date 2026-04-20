using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models.AuthEntities;
using ElectroManagement.Helpers; // QUAN TRỌNG: Thêm dòng này để gọi được SecurityHelper

namespace ElectroManagement.Controllers.Auth
{
    public class AuthController
    {
        /// <summary>
        /// Hàm xử lý đăng nhập
        /// </summary>
        public User Login(string username, string password)
        {
            // 1. BĂM MẬT KHẨU NGƯỜI DÙNG NHẬP VÀO
            string hashedPassword = SecurityHelper.HashPassword(password);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT u.UserID, u.Username, u.RoleID, u.IsActive, r.RoleName 
                    FROM Users u
                    LEFT JOIN Roles r ON u.RoleID = r.RoleID
                    WHERE u.Username = @username AND u.Password = @password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                // 2. SO SÁNH VỚI MẬT KHẨU ĐÃ BĂM TRONG DATABASE
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool isActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]);

                        if (!isActive)
                        {
                            return null;
                        }

                        User loggedInUser = new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            RoleID = reader["RoleID"] != DBNull.Value ? Convert.ToInt32(reader["RoleID"]) : (int?)null,
                            RoleName = reader["RoleName"] != DBNull.Value ? reader["RoleName"].ToString() : "Chưa cấp quyền",
                            IsActive = isActive
                        };

                        return loggedInUser;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Hàm xử lý Đổi mật khẩu
        /// </summary>
        public bool ChangePassword(int userId, string newPassword)
        {
            // KHI ĐỔI MẬT KHẨU CŨNG PHẢI BĂM MẬT KHẨU MỚI TRƯỚC KHI LƯU VÀO DB
            string hashedNewPassword = SecurityHelper.HashPassword(newPassword);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Users SET Password = @newPassword WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                // LƯU MẬT KHẨU ĐÃ BĂM
                cmd.Parameters.AddWithValue("@newPassword", hashedNewPassword);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}