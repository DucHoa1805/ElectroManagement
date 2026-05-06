using System;
using System.Windows.Forms;
using ElectroManagement.Models.OrderEntities;

namespace ElectroManagement.Controllers.Orders
{
    /// <summary>
    /// Advanced Order Controller - Xử lý quy trình Đơn hàng + Thanh toán + Xuất kho
    /// Tách riêng từ OrderController cũ để không ảnh hưởng code hiện tại
    /// </summary>
    public class OrderBusinessController
    {
        /// <summary>
        /// Tạo đơn hàng mới với trạng thái "Pending"
        /// </summary>
        public int CreateOrder(Order order)
        {
            try
            {
                // Giả lập tạo đơn hàng - trong thực tế sẽ lưu vào DB
                // Tạm thời trả về một ID tăng dần
                int orderId = DateTime.Now.Millisecond; // Sử dụng millisecond làm ID tạm

                MessageBox.Show(
                    $"✓ Đã tạo đơn hàng #{orderId}\n" +
                    $"Khách hàng: {order.CustomerName}\n" +
                    $"Tổng tiền: {order.TotalAmount:N0} VNĐ\n" +
                    $"Trạng thái: {order.Status}",
                    "Đơn Hàng Mới", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                return orderId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi");
                return -1;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái đơn hàng
        /// </summary>
        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                // Giả lập update status
                MessageBox.Show(
                    $"Đơn hàng #{orderId} cập nhật trạng thái: {newStatus}",
                    "Cập Nhật Trạng Thái", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        public Order GetOrder(int orderId)
        {
            // Giả lập lấy đơn hàng
            return new Order
            {
                OrderId = orderId,
                Status = "Pending",
                CreatedAt = DateTime.Now
            };
        }
    }
}
