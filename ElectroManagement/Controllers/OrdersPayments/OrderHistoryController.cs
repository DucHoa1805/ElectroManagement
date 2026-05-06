using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;

namespace ElectroManagement.Controllers.Orders
{
    public class OrderHistoryController
    {
        public DataTable GetOrderHistory()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        OrderID, 
                        CustomerName, 
                        Phone, 
                        TotalAmount, 
                        Status, 
                        OrderDate 
                    FROM Orders 
                    ORDER BY OrderDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetOrderDetails(int orderId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        od.VariantID,
                        (SELECT ProductName FROM Products WHERE ProductID = pv.ProductID) + ' - ' + pv.Color + ' - ' + pv.Storage AS ProductName,
                        od.Quantity,
                        od.UnitPrice,
                        (od.Quantity * od.UnitPrice) AS SubTotal
                    FROM OrderDetails od
                    INNER JOIN ProductVariants pv ON od.VariantID = pv.VariantID
                    WHERE od.OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
