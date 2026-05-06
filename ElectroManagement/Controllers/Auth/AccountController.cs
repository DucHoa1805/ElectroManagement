using ElectroManagement.Database;
using ElectroManagement.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Helpers; // Dùng để truy cập Session

namespace ElectroManagement.Controllers.Auth
{
    public class AccountController
    {
        // Hàm phụ để ghi vào hệ thống AuditLog
        private void LogAction(SqlConnection conn, SqlTransaction trans, string action, string tableName)
        {
            try
            {
                // Lấy UserID từ Session (Nếu chưa đăng nhập thì gán 1 làm mặc định)
                int currentUserId = Session.CurrentUser != null ? Session.CurrentUser.UserID : 1;

                string query = @"INSERT INTO AuditLogs (UserID, Action, TableName, CreatedAt) 
                                 VALUES (@UserID, @Action, @TableName, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(query, conn, trans);
                cmd.Parameters.AddWithValue("@UserID", currentUserId);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@TableName", tableName);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // Bỏ qua lỗi ghi log để không ảnh hưởng hoạt động chính
            }
        }

        // 1. Lấy danh sách hiển thị
        public DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();
            // Lấy hiển thị thì giấu cái hash Password đi bằng chữ "Đã mã hóa ***" cho bảo mật
            string query = "SELECT UserID, Username, '***' as Password, RoleID, IsActive FROM Users";

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

        // 2. Thêm tài khoản mới (Có mã hóa MK + Có ghi log)
        public bool AddAccount(Account acc)
        {
            string query = "INSERT INTO Users (Username, Password, RoleID, IsActive) " +
                           "VALUES (@Username, @Password, @RoleID, @IsActive)";

            // Gọi hàm Hash SHA256 trước khi Insert
            string hashedPassword = SecurityHelper.HashPassword(acc.Password);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Username", acc.Username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword); // Lưu hash
                        cmd.Parameters.AddWithValue("@RoleID", acc.RoleID);
                        cmd.Parameters.AddWithValue("@IsActive", acc.IsActive);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LogAction(conn, trans, $"Thêm mới Account: {acc.Username}", "Users");
                            trans.Commit();
                            return true;
                        }
                    }
                }
                catch
                {
                    trans.Rollback();
                }
            }
            return false;
        }

        // 3. Cập nhật thông tin tài khoản (Có kiểm tra mã hóa MK + Có ghi log)
        public bool UpdateAccount(Account acc)
        {
            // Chỉ cập nhật mật khẩu nếu người dùng thực sự nhập mật khẩu mới (khác "***" và không rỗng)
            bool isUpdatePassword = !string.IsNullOrEmpty(acc.Password) && acc.Password != "***";

            string query = "";
            if (isUpdatePassword)
            {
                query = "UPDATE Users SET Password = @Password, RoleID = @RoleID, IsActive = @IsActive WHERE Username = @Username";
            }
            else
            {
                // Giữ nguyên mật khẩu cũ
                query = "UPDATE Users SET RoleID = @RoleID, IsActive = @IsActive WHERE Username = @Username";
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Username", acc.Username);

                        if (isUpdatePassword)
                        {
                            string hashedPassword = SecurityHelper.HashPassword(acc.Password);
                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        }

                        cmd.Parameters.AddWithValue("@RoleID", acc.RoleID);
                        cmd.Parameters.AddWithValue("@IsActive", acc.IsActive);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LogAction(conn, trans, $"Cập nhật Account: {acc.Username}", "Users");
                            trans.Commit();
                            return true;
                        }
                    }
                }
                catch
                {
                    trans.Rollback();
                }
            }
            return false;
        }

        // 4. Xóa tài khoản (Có ghi log)
        public bool DeleteAccount(string username)
        {
            string query = "DELETE FROM Users WHERE Username = @Username";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LogAction(conn, trans, $"Xóa Account: {username}", "Users");
                            trans.Commit();
                            return true;
                        }
                    }
                }
                catch
                {
                    trans.Rollback();
                }
            }
            return false;
        }
    }
}
