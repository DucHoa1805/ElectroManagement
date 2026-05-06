using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models.ProductEntities; // Quan trọng: Phải using thư mục Models

namespace ElectroManagement.Controllers.Products
{
    public class BrandController
    {
        // Vẫn dùng DataTable cho GetAll để đổ lên DataGridView nhanh nhất
        public DataTable GetAll()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT BrandID, BrandName FROM Brands";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Dùng Model cho Thêm mới
        public void Add(Brand b) // Truyền vào object Brand
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Brands (BrandName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", b.BrandName); // Lấy từ Model

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Thêm mới Nhãn hàng: {b.BrandName}", "Brands");
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Dùng Model cho Cập nhật
        public void Update(Brand b) // Truyền vào object Brand
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Brands SET BrandName = @name WHERE BrandID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", b.BrandID);     // Lấy từ Model
                cmd.Parameters.AddWithValue("@name", b.BrandName); // Lấy từ Model

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Cập nhật Nhãn hàng: {b.BrandName}", "Brands");
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Brands WHERE BrandID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    LogAction(conn, trans, $"Xóa Nhãn hàng ID: {id}", "Brands");
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