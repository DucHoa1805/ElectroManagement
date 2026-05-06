using System;
using System.Windows.Forms;
// Cập nhật đường dẫn namespace mới
using ElectroManagement.Controllers.Report.AuditLog;
using ElectroManagement.Models.Report.AuditLog;

namespace ElectroManagement.Views.Orders
{
    public partial class frmAuditLog : Form
    {
        private readonly AuditController _ctrl = new AuditController();

        public frmAuditLog()
        {
            InitializeComponent();

            // Dùng Shown để giao diện hiện lên trước khi gọi Data
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

                // Tự động giãn cột cho đẹp
                dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị nhật ký: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm (Ví dụ kiểm tra)
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            bool result = _ctrl.AddLog(1, "Kiểm tra hệ thống", "AuditLogs");
            if (result) LoadData();
        }

        // Nút Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            try
            {
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
                if (dgvAuditLogs.CurrentRow.Cells["LogID"].Value != null)
                {
                    int id = (int)dgvAuditLogs.CurrentRow.Cells["LogID"].Value;
                    if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (_ctrl.DeleteLog(id))
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadData();
                        }
                    }
                }
            }
        }

        // Nút Làm mới dữ liệu
        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
    }
}