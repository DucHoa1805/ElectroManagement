using ElectroManagement.Database;
// Đổi đường dẫn Models thành Report.AuditLog
using ElectroManagement.Models.Report.AuditLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElectroManagement.Controllers.Report.AuditLog
{
    public class AuditController
    {
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

        public List<Audit> SearchLogs(string keyword)
        {
            List<Audit> list = new List<Audit>();
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

        /// <summary>
        /// Thêm một bản ghi vào bảng AuditLogs
        /// </summary>
        public bool AddLog(int? userId, string action, string tableName)
        {
            string sql = @"INSERT INTO AuditLogs (UserID, Action, TableName, CreatedAt)
                           VALUES (@UserID, @Action, @TableName, @CreatedAt)";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (userId.HasValue)
                    cmd.Parameters.AddWithValue("@UserID", userId.Value);
                else
                    cmd.Parameters.AddWithValue("@UserID", DBNull.Value);

                cmd.Parameters.AddWithValue("@Action", action ?? string.Empty);
                cmd.Parameters.AddWithValue("@TableName", tableName ?? string.Empty);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        /// <summary>
        /// Xóa một log theo id
        /// </summary>
        public bool DeleteLog(int id)
        {
            string sql = "DELETE FROM AuditLogs WHERE LogID = @LogID";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LogID", id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

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