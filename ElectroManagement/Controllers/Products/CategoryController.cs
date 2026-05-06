using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models.ProductEntities; // Đừng quên using thư mục Models nhé

namespace ElectroManagement.Controllers.Products
{
    public class CategoryController
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                // Vẫn giữ IsDeleted = 0 để lọc các danh mục chưa bị xóa mềm
                string query = "SELECT CategoryID, CategoryName FROM Categories WHERE IsDeleted = 0";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Truyền vào object Category thay vì chuỗi string đơn lẻ
        public void Add(Category c)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Categories (CategoryName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", c.CategoryName);

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Thêm mới Danh mục: {c.CategoryName}", "Categories");
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Truyền vào object Category để lấy cả ID và Name
        public void Update(Category c)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Categories SET CategoryName = @name WHERE CategoryID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", c.CategoryID);
                cmd.Parameters.AddWithValue("@name", c.CategoryName);

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Cập nhật Danh mục: {c.CategoryName}", "Categories");
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Xóa thường chỉ cần ID nên giữ nguyên int id là ổn nhất
        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Categories SET IsDeleted = 1 WHERE CategoryID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Xóa Danh mục ID: {id}", "Categories");
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        private void LogAction(SqlConnection conn, SqlTransaction trans, string action, string tableName)
        {
            try
            {
                int currentUserId = ElectroManagement.Helpers.Session.CurrentUser != null ? ElectroManagement.Helpers.Session.CurrentUser.UserID : 1;
                string query = @"INSERT INTO AuditLogs (UserID, Action, TableName, CreatedAt) 
                                 VALUES (@UserID, @Action, @TableName, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(query, conn, trans);
                cmd.Parameters.AddWithValue("@UserID", currentUserId);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@TableName", tableName);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }
    }
}