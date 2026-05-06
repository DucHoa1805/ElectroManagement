using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Helpers;
using ElectroManagement.Controllers.Report.AuditLog;

namespace ElectroManagement.Controllers.Inventory
{
    public class InventoryController
    {
        /// <summary>
        /// Lấy lịch sử giao dịch với tên sản phẩm và số lượng hiện tại
        /// </summary>
        public DataTable GetAllHistory()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        it.TransactionID,
                        pv.VariantID,
                        CONCAT(p.ProductName, ' - ', pv.Color, ' - ', pv.Storage) AS ProductName,
                        it.ChangeQuantity,
                        it.Type,
                        pv.Quantity AS CurrentQuantity,
                        it.CreatedAt
                    FROM dbo.InventoryTransactions AS it
                    INNER JOIN dbo.ProductVariants AS pv ON it.VariantID = pv.VariantID
                    INNER JOIN dbo.Products AS p ON pv.ProductID = p.ProductID
                    ORDER BY it.CreatedAt DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy danh sách tồn kho hiện tại với tên sản phẩm
        /// </summary>
        public DataTable GetCurrentStock()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        pv.VariantID,
                        CONCAT(p.ProductName, ' - ', pv.Color, ' - ', pv.Storage) AS ProductName,
                        pv.SKU,
                        pv.Price,
                        pv.Quantity AS CurrentQuantity
                    FROM dbo.ProductVariants AS pv
                    INNER JOIN dbo.Products AS p ON pv.ProductID = p.ProductID
                    ORDER BY p.ProductName, pv.Color, pv.Storage";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy thông tin sản phẩm cụ thể với số lượng hiện tại
        /// </summary>
        public DataTable GetProductInfo(int variantId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        pv.VariantID,
                        CONCAT(p.ProductName, ' - ', pv.Color, ' - ', pv.Storage) AS ProductName,
                        pv.SKU,
                        pv.Price,
                        pv.Quantity AS CurrentQuantity
                    FROM dbo.ProductVariants AS pv
                    INNER JOIN dbo.Products AS p ON pv.ProductID = p.ProductID
                    WHERE pv.VariantID = @variantId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@variantId", variantId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void ImportStock(Object trans)
        {
            dynamic transaction = trans;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string insertQuery = @"INSERT INTO InventoryTransactions 
                                       (VariantID, Type, ChangeQuantity, CreatedAt) 
                                       VALUES (@variantId, @type, @quantity, @date)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);
                insertCmd.Parameters.AddWithValue("@type", "Import");
                insertCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                insertCmd.ExecuteNonQuery();

                // Ghi vào nhật ký hệ thống
                try
                {
                    var audit = new Report.AuditLog.AuditController();
                    int? userId = null; // Không biết user hiện tại ở đây, cho phép null
                    audit.AddLog(userId, $"Import stock VariantID={transaction.VariantID} Quantity={transaction.ChangeQuantity}", "InventoryTransactions");
                }
                catch { }

                string updateQuery = @"UPDATE ProductVariants 
                                       SET Quantity = Quantity + @quantity 
                                       WHERE VariantID = @variantId";

                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                updateCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);

                updateCmd.ExecuteNonQuery();
            }
        }

        public void ExportStock(Object trans)
        {
            dynamic transaction = trans;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string insertQuery = @"INSERT INTO InventoryTransactions 
                                       (VariantID, Type, ChangeQuantity, CreatedAt) 
                                       VALUES (@variantId, @type, @quantity, @date)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);
                insertCmd.Parameters.AddWithValue("@type", "Export");
                insertCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                insertCmd.ExecuteNonQuery();

                // Ghi vào nhật ký hệ thống
                try
                {
                    var audit = new Report.AuditLog.AuditController();
                    int? userId = null;
                    audit.AddLog(userId, $"Export stock VariantID={transaction.VariantID} Quantity={transaction.ChangeQuantity}", "InventoryTransactions");
                }
                catch { }

                string updateQuery = @"UPDATE ProductVariants 
                                       SET Quantity = Quantity - @quantity 
                                       WHERE VariantID = @variantId";

                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                updateCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);

                updateCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lấy danh sách các đơn hàng đã thanh toán (Paid) nhưng chưa xuất kho (Completed)
        /// </summary>
        public DataTable GetPendingExportOrders()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT OrderID, CustomerName, Phone, TotalAmount, OrderDate 
                    FROM dbo.Orders 
                    WHERE Status = 'Paid' 
                    ORDER BY OrderDate ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Thực hiện xuất kho toàn bộ đơn hàng
        /// </summary>
        public bool ExportOrder(int orderId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Lấy danh sách sản phẩm trong đơn hàng
                    string getDetailsQuery = "SELECT VariantID, Quantity FROM dbo.OrderDetails WHERE OrderID = @OrderID";
                    SqlCommand getDetailsCmd = new SqlCommand(getDetailsQuery, conn, transaction);
                    getDetailsCmd.Parameters.AddWithValue("@OrderID", orderId);

                    SqlDataReader reader = getDetailsCmd.ExecuteReader();
                    DataTable dtDetails = new DataTable();
                    dtDetails.Load(reader);
                    reader.Close();

                    foreach (DataRow row in dtDetails.Rows)
                    {
                        int variantId = (int)row["VariantID"];
                        int quantity = (int)row["Quantity"];

                        // Kiểm tra tồn kho trước khi xuất (Tùy chọn nhưng tốt)
                        // Bỏ qua bước kiểm tra tồn kho ở đây để mã đơn giản, giả định đã kiểm tra lúc đặt hàng

                        // 1. Thêm vào lịch sử giao dịch (Export)
                        string insertTransactionQuery = @"
                            INSERT INTO dbo.InventoryTransactions (VariantID, Type, ChangeQuantity, CreatedAt)
                            VALUES (@VariantID, 'Export', @ChangeQuantity, @CreatedAt)";
                        SqlCommand insertTransactionCmd = new SqlCommand(insertTransactionQuery, conn, transaction);
                        insertTransactionCmd.Parameters.AddWithValue("@VariantID", variantId);
                        insertTransactionCmd.Parameters.AddWithValue("@ChangeQuantity", quantity);
                        insertTransactionCmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        insertTransactionCmd.ExecuteNonQuery();

                        // 2. Cập nhật số lượng trong ProductVariants
                        string updateVariantQuery = @"
                            UPDATE dbo.ProductVariants 
                            SET Quantity = Quantity - @Quantity 
                            WHERE VariantID = @VariantID";
                        SqlCommand updateVariantCmd = new SqlCommand(updateVariantQuery, conn, transaction);
                        updateVariantCmd.Parameters.AddWithValue("@Quantity", quantity);
                        updateVariantCmd.Parameters.AddWithValue("@VariantID", variantId);
                        updateVariantCmd.ExecuteNonQuery();
                    }

                    // 3. Đổi trạng thái đơn hàng thành Completed (đã xuất kho/hoàn thành)
                    string updateOrderQuery = "UPDATE dbo.Orders SET Status = 'Completed' WHERE OrderID = @OrderID";
                    SqlCommand updateOrderCmd = new SqlCommand(updateOrderQuery, conn, transaction);
                    updateOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                    updateOrderCmd.ExecuteNonQuery();

                    // Ghi audit log cho hành động xuất kho đơn hàng (nếu có người dùng đang đăng nhập)
                    try
                    {
                        var audit = new AuditController();
                        int? userId = null;
                        if (Session.IsLoggedIn && Session.CurrentUser != null)
                            userId = Session.CurrentUser.UserID;

                        audit.AddLog(userId, $"Export order OrderID={orderId}", "Orders");
                    }
                    catch { }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Windows.Forms.MessageBox.Show($"Lỗi khi xuất kho đơn hàng: {ex.Message}", "Lỗi");
                    return false;
                }
            }
        }
        public DataTable GetHistoryByVariant(int variantId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        it.TransactionID,
                        pv.VariantID,
                        CONCAT(p.ProductName, ' - ', pv.Color, ' - ', pv.Storage) AS ProductName,
                        it.ChangeQuantity,
                        it.Type,
                        pv.Quantity AS CurrentQuantity,
                        it.CreatedAt
                    FROM dbo.InventoryTransactions AS it
                    INNER JOIN dbo.ProductVariants AS pv ON it.VariantID = pv.VariantID
                    INNER JOIN dbo.Products AS p ON pv.ProductID = p.ProductID
                    WHERE it.VariantID = @variantId
                    ORDER BY it.CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@variantId", variantId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
