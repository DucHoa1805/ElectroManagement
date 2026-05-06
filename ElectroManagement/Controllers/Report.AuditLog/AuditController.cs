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

        internal bool AddLog(int v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteLog(int id)
        {
            throw new NotImplementedException();
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