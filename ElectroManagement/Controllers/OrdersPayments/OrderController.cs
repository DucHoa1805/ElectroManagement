using System;
using System.Windows.Forms;

namespace ElectroManagement.Controllers.Orders
{
    public class OrderController
    {
   
        public void AddOrder()
        {
   
            MessageBox.Show("Controller xử lý: Đã thêm đơn hàng mới thành công!", "Thông báo");
        }

    
        public void UpdateOrder()
        {
            MessageBox.Show("Controller xử lý: Đã cập nhật đơn hàng!", "Thông báo");
        }

    
        public void DeleteOrder()
        {
            MessageBox.Show("Controller xử lý: Đã xóa đơn hàng!", "Thông báo");
        }

    }
}