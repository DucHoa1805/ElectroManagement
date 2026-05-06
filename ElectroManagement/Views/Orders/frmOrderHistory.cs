using System;
using System.Data;
using System.Windows.Forms;
using ElectroManagement.Controllers.Orders;

namespace ElectroManagement.Views.Orders
{
    public partial class frmOrderHistory : Form
    {
        private OrderHistoryController _controller;

        public frmOrderHistory()
        {
            InitializeComponent();
            _controller = new OrderHistoryController();
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            try
            {
                DataTable dt = _controller.GetOrderHistory();
                dgvOrderHistory.DataSource = dt;

                // Format columns
                if(dgvOrderHistory.Columns["TotalAmount"] != null)
                {
                    dgvOrderHistory.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    dgvOrderHistory.Columns["TotalAmount"].HeaderText = "Tổng tiền (VNĐ)";
                }

                if(dgvOrderHistory.Columns["OrderDate"] != null)
                {
                    dgvOrderHistory.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvOrderHistory.Columns["OrderDate"].HeaderText = "Ngày tạo";
                }

                // Đổi tên một vài cột khác
                try
                {
                    if (dgvOrderHistory.Columns["OrderID"] != null) dgvOrderHistory.Columns["OrderID"].HeaderText = "Mã Đơn";
                    if (dgvOrderHistory.Columns["CustomerName"] != null) dgvOrderHistory.Columns["CustomerName"].HeaderText = "Khách hàng";
                    if (dgvOrderHistory.Columns["Phone"] != null) dgvOrderHistory.Columns["Phone"].HeaderText = "SĐT";
                    if (dgvOrderHistory.Columns["Status"] != null) dgvOrderHistory.Columns["Status"].HeaderText = "Trạng thái";
                }
                catch { }

                // Ẩn cột ID nếu cần
                // if(dgvOrderHistory.Columns["OrderID"] != null) dgvOrderHistory.Columns["OrderID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử đơn hàng: {ex.Message}", "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void dgvOrderHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào nút "Xem chi tiết" (giả sử cột cuối là nút)
            if (e.RowIndex >= 0 && dgvOrderHistory.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int orderId = Convert.ToInt32(dgvOrderHistory.Rows[e.RowIndex].Cells["OrderID"].Value);
                ShowOrderDetails(orderId);
            }
        }

        private void ShowOrderDetails(int orderId)
        {
             DataTable dtDetails = _controller.GetOrderDetails(orderId);

             // Tạo một form hiển thị chi tiết (có thể dùng luôn DataGridView trên form hoặc popup)
             Form frmDetail = new Form();
             frmDetail.Text = $"Chi tiết đơn hàng {orderId}";
             frmDetail.Size = new System.Drawing.Size(600, 400);
             frmDetail.StartPosition = FormStartPosition.CenterParent;

             DataGridView dgvDetail = new DataGridView();
             dgvDetail.Dock = DockStyle.Fill;
             dgvDetail.AllowUserToAddRows = false;
             dgvDetail.ReadOnly = true;
             dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             dgvDetail.DataSource = dtDetails;

             // Format cột giá
             if(dgvDetail.Columns["UnitPrice"] != null)
                 dgvDetail.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";

             frmDetail.Controls.Add(dgvDetail);
             frmDetail.ShowDialog();
        }
    }
}
