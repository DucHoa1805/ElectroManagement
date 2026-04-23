using ElectroManagement.Database;
// Đổi đường dẫn Models thành Report.AuditLog
using ElectroManagement.Models.Report.AuditLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElectroManagement.Controllers.Report.AuditLog
{
    public class ReportController
    {
        public List<RevenueReport> GetRevenueReport(DateTime from, DateTime to)
        {
            List<RevenueReport> list = new List<RevenueReport>();
            string sql = "SELECT OrderID, OrderDate, TotalAmount, Status, PaymentStatus FROM Orders WHERE OrderDate BETWEEN @f AND @t";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f", from.Date);
                cmd.Parameters.AddWithValue("@t", to.Date.AddDays(1).AddSeconds(-1));

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new RevenueReport
                    {
                        OrderID = (int)rdr["OrderID"],
                        OrderDate = (DateTime)rdr["OrderDate"],
                        TotalAmount = (decimal)rdr["TotalAmount"],
                        Status = rdr["Status"].ToString(),
                        PaymentStatus = rdr["PaymentStatus"].ToString()
                    });
                }
            }
            return list;
        }
    }
}