using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models.Orders;

namespace ElectroManagement.Controllers
{
    public class AuditController
    {
        // 1. Hàm truy vấn toàn bộ dữ liệu
        public List<Audit> GetAllLogs()
        {
            List<Audit> list = new List<Audit>();
            string sql = "SELECT a.*, u.Username FROM AuditLogs a LEFT JOIN Users u ON a.UserID = u.UserID ORDER BY CreatedAt DESC";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(MapReaderToAudit(rdr));
                }
            }
            return list;
        }

        // --- BỔ SUNG: 2. Hàm Tìm kiếm Nhật ký ---
        public List<Audit> SearchLogs(string keyword)
        {
            List<Audit> list = new List<Audit>();
            // Sử dụng LIKE để tìm kiếm gần đúng trong các cột quan trọng
            string sql = @"SELECT a.*, u.Username 
                           FROM AuditLogs a 
                           LEFT JOIN Users u ON a.UserID = u.UserID 
                           WHERE u.Username LIKE @key 
                              OR a.Action LIKE @key 
                              OR a.TableName LIKE @key 
                           ORDER BY a.CreatedAt DESC";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Thêm ký tự % để tìm kiếm chứa từ khóa
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(MapReaderToAudit(rdr));
                }
            }
            return list;
        }

        // 3. Hàm Thêm Nhật ký
        public bool AddLog(int? userId, string action, string tableName)
        {
            string sql = "INSERT INTO AuditLogs (UserID, Action, TableName, CreatedAt) VALUES (@uid, @act, @tbl, GETDATE())";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", (object)userId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@act", action);
                cmd.Parameters.AddWithValue("@tbl", tableName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. Hàm Xóa Nhật ký
        public bool DeleteLog(int logId)
        {
            string sql = "DELETE FROM AuditLogs WHERE LogID = @id";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", logId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Hàm phụ trợ để tránh lặp code khi đọc dữ liệu từ SQL
        private Audit MapReaderToAudit(SqlDataReader rdr)
        {
            return new Audit
            {
                LogID = (int)rdr["LogID"],
                Username = rdr["Username"]?.ToString() ?? "Hệ thống",
                Action = rdr["Action"].ToString(),
                TableName = rdr["TableName"].ToString(),
                CreatedAt = (DateTime)rdr["CreatedAt"]
            };
        }
    }
}