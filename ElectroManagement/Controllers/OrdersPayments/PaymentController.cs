using System;
using System.Windows.Forms;

namespace ElectroManagement.Controllers.Orders
{
    public class PaymentController
    {
        
        public void ProcessPayment(string paymentMethod, decimal totalAmount)
        {
            
            MessageBox.Show($"Đã xác nhận thu tiền thành công!\n- Phương thức: {paymentMethod}\n- Số tiền: {totalAmount:N0} VNĐ",
                            "Thanh toán thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}