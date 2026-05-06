using System;
using System.Windows.Forms;
using ElectroManagement.Models.OrderEntities;
using ElectroManagement.Controllers.Orders;
using ElectroManagement.Views.Orders;

namespace ElectroManagement.Helpers
{
    /// <summary>
    /// Helper class để kết nối quy trình Đơn Hàng → Thanh Toán → Xuất Kho
    /// Không sửa frmOrder hiện tại, sử dụng helper này để xử lý logic
    /// </summary>
    public class OrderFlowHelper
    {
        private OrderBusinessController _orderController;
        private Order _currentOrder;

        public OrderFlowHelper()
        {
            _orderController = new OrderBusinessController();
        }

        /// <summary>
        /// Bước 1: Tạo đơn hàng từ thông tin giỏ hàng của frmOrder
        /// </summary>
        public int CreateOrderFromCart(
            string customerName, 
            string phone, 
            decimal totalAmount, 
            System.Collections.Generic.List<OrderDetail> orderDetails)
        {
            try
            {
                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo");
                    return -1;
                }

                // Tạo Order object
                _currentOrder = new Order
                {
                    CustomerName = customerName,
                    Phone = phone ?? "",
                    TotalAmount = totalAmount,
                    Status = "Pending",
                    CreatedAt = DateTime.Now,
                    OrderDetails = orderDetails
                };

                // Gọi controller để tạo order
                int orderId = _orderController.CreateOrder(_currentOrder);

                if (orderId > 0)
                {
                    // Mở form thanh toán với OrderId
                    frmPayment formThanhToan = new frmPayment(totalAmount);
                    formThanhToan.ShowDialog();

                    return orderId;
                }

                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi");
                return -1;
            }
        }

        /// <summary>
        /// Lấy thông tin đơn hàng hiện tại
        /// </summary>
        public Order GetCurrentOrder()
        {
            return _currentOrder;
        }

        /// <summary>
        /// Reset helper sau khi xong một quy trình
        /// </summary>
        public void Reset()
        {
            _currentOrder = null;
        }
    }
}
