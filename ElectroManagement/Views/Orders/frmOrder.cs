using System;
using System.ComponentModel;
using System.Windows.Forms;
using ElectroManagement.Models.OrderEntities;

namespace ElectroManagement.Views.Orders
{
    public partial class frmOrder : Form
    {
      
        private BindingList<OrderDetail> _gioHang = new BindingList<OrderDetail>();

        public frmOrder()
        {
            InitializeComponent();

            
            dgvOrderDetails.DataSource = _gioHang;
        }

       
       
        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
          
        }
       

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenSanPham = cmbProduct.Text;
            int soLuong = (int)nudQuantity.Value;

            if (string.IsNullOrEmpty(tenSanPham) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và số lượng!", "Nhắc nhở");
                return;
            }

            decimal giaBan = 30000000; 

            OrderDetail monHang = new OrderDetail
            {
                ProductName = tenSanPham,
                Quantity = soLuong,
                UnitPrice = giaBan,
                SubTotal = giaBan * soLuong
            };

            _gioHang.Add(monHang);
        }

      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow != null)
            {
                _gioHang.RemoveAt(dgvOrderDetails.CurrentRow.Index);
            }
        }

      
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            decimal tongTien = 0;
            foreach (var item in _gioHang)
            {
                tongTien += item.SubTotal;
            }

            if (tongTien == 0)
            {
                MessageBox.Show("Giỏ hàng trống trơn!", "Báo lỗi");
                return;
            }

            frmPayment formThanhToan = new frmPayment(tongTien);
            formThanhToan.ShowDialog();
        }

     
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (dgvOrderDetails.CurrentRow != null)
            {
               
                int viTri = dgvOrderDetails.CurrentRow.Index;

             
                string tenSanPhamMoi = cmbProduct.Text;
                int soLuongMoi = (int)nudQuantity.Value;

                if (string.IsNullOrEmpty(tenSanPhamMoi) || soLuongMoi <= 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và số lượng hợp lệ!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                decimal giaBan = 30000000;

             
                _gioHang[viTri].ProductName = tenSanPhamMoi;
                _gioHang[viTri].Quantity = soLuongMoi;
                _gioHang[viTri].UnitPrice = giaBan;
                _gioHang[viTri].SubTotal = giaBan * soLuongMoi;

              
                _gioHang.ResetItem(viTri);

                MessageBox.Show("Đã cập nhật món hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              
                MessageBox.Show("Vui lòng chọn một dòng trong giỏ hàng để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     
        private void btnReset_Click(object sender, EventArgs e)
        {
           
            _gioHang.Clear();
        }
    }
}