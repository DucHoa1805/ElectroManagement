using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ElectroManagement.Database;

namespace ElectroManagement.Controllers.Orders
{
    public class PaymentController
    {
        public bool ProcessPayment(int orderId, string paymentMethod, decimal totalAmount)
        {
            if (orderId <= 0)
            {
                MessageBox.Show("Mã đơn hàng không hợp lệ, không thể thanh toán.", "Lỗi");
                return false;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Cập nhật trạng thái đơn hàng thành Paid (Đã thanh toán) nhưng chưa xuất kho
                    string updateOrderQuery = "UPDATE Orders SET Status = 'Paid' WHERE OrderID = @OrderID";
                    SqlCommand updateOrderCmd = new SqlCommand(updateOrderQuery, conn, transaction);
                    updateOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                    updateOrderCmd.ExecuteNonQuery();

                    // 2. Thêm vào bảng Payments
                    string insertPaymentQuery = @"
                        INSERT INTO Payments (OrderID, PaymentMethod, Amount, PaidAt)
                        VALUES (@OrderID, @PaymentMethod, @Amount, @PaidAt)";
                    SqlCommand insertPaymentCmd = new SqlCommand(insertPaymentQuery, conn, transaction);
                    insertPaymentCmd.Parameters.AddWithValue("@OrderID", orderId);
                    insertPaymentCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    insertPaymentCmd.Parameters.AddWithValue("@Amount", totalAmount);
                    insertPaymentCmd.Parameters.AddWithValue("@PaidAt", DateTime.Now);
                    insertPaymentCmd.ExecuteNonQuery();

                    // KHÔNG TRỪ KHO Ở ĐÂY NỮA, ĐỂ BÊN FORM INVENTORY XỬ LÝ

                    transaction.Commit();

                    MessageBox.Show($"Thanh toán thành công!\n- Phương thức: {paymentMethod}\n- Số tiền: {totalAmount:N0} VNĐ\n\nĐơn hàng đã được chuyển xuống bộ phận Kho để chờ xuất.",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi");
                    return false;
                }
            }
        }
    }
}
