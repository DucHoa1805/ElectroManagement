using System;
using System.Windows.Forms;
using ElectroManagement.Controllers;

namespace ElectroManagement.Views.Orders
{
    public partial class frmAuditLog : Form
    {
        private readonly AuditController _ctrl = new AuditController();

        public frmAuditLog()
        {
            InitializeComponent();

            // Thay đổi ở đây: Dùng Shown thay vì Load để giao diện hiện lên trước khi gọi Data
            this.Shown += (s, e) => LoadData();
        }

        // Hàm Load dữ liệu
        private void LoadData()
        {
            try
            {
                // Gọi hàm truy vấn từ Controller
                var logs = _ctrl.GetAllLogs();
                dgvAuditLogs.DataSource = logs;
            }
            catch (Exception ex)
            {
                // Lúc này Form đã hiện rồi, nên thông báo lỗi sẽ hiện đè lên giao diện
                MessageBox.Show("Lỗi hiển thị nhật ký: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm (Ví dụ khi người dùng làm gì đó)
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            bool result = _ctrl.AddLog(1, "Kiểm tra hệ thống", "AuditLogs");
            if (result) LoadData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim(); // Giả sử TextBox tìm kiếm tên là txtSearch

            try
            {
                // Gọi hàm SearchLogs vừa thêm ở trên
                var results = _ctrl.SearchLogs(keyword);
                dgvAuditLogs.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa nhật ký đang chọn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAuditLogs.CurrentRow != null)
            {
                // Kiểm tra xem cột LogID có tồn tại không để tránh lỗi ép kiểu
                if (dgvAuditLogs.CurrentRow.Cells["LogID"].Value != null)
                {
                    int id = (int)dgvAuditLogs.CurrentRow.Cells["LogID"].Value;
                    if (_ctrl.DeleteLog(id))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                    }
                }
            }
        }

        // Nút Làm mới dữ liệu
        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
    }
}