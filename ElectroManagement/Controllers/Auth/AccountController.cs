using ElectroManagement.Database;
using ElectroManagement.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ElectroManagement.Controllers.Auth
{
    public class AccountController
    {
        // 1. Lấy danh sách hiển thị lên DataGridView
        public DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();
            // Đổi tên bảng thành Users và gọi đúng các cột
            string query = "SELECT UserID, Username, Password, RoleID, IsActive FROM Users";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi kết nối CSDL: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        // 2. Thêm tài khoản mới
        public bool AddAccount(Account acc)
        {
            string query = "INSERT INTO Users (Username, Password, RoleID, IsActive) " +
                           "VALUES (@Username, @Password, @RoleID, @IsActive)";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", acc.Username);
                    cmd.Parameters.AddWithValue("@Password", acc.Password);
                    cmd.Parameters.AddWithValue("@RoleID", acc.RoleID);
                    cmd.Parameters.AddWithValue("@IsActive", acc.IsActive);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // 3. Cập nhật thông tin tài khoản
        public bool UpdateAccount(Account acc)
        {
            string query = "UPDATE Users SET Password = @Password, RoleID = @RoleID, IsActive = @IsActive " +
                           "WHERE Username = @Username";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", acc.Username);
                    cmd.Parameters.AddWithValue("@Password", acc.Password);
                    cmd.Parameters.AddWithValue("@RoleID", acc.RoleID);
                    cmd.Parameters.AddWithValue("@IsActive", acc.IsActive);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // 4. Xóa tài khoản
        public bool DeleteAccount(string username)
        {
            string query = "DELETE FROM Users WHERE Username = @Username";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}