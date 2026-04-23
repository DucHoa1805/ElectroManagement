using System;
using System.Windows.Forms;
using ElectroManagement.Controllers.Auth;
using ElectroManagement.Models;

namespace ElectroManagement.Views.Account
{
    public partial class frmAccount : Form
    {
        private AccountController accountController;

        public frmAccount()
        {
            InitializeComponent();
            accountController = new AccountController();
        }

        // 1. Sự kiện khi mở Form sẽ tự động tải dữ liệu
        private void frmAccount_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho ComboBox Vai trò
            cboRole.SelectedIndex = 0;
            LoadData();
        }

        // Hàm load dữ liệu dùng chung
        private void LoadData()
        {
            try
            {
                dgvAccounts.DataSource = accountController.GetAllAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Sự kiện khi click vào một dòng trong bảng (DataGridView)
        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];

                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

                // Dựa theo DB của bạn: 1 là Admin, 2 là Staff 
                int roleId = Convert.ToInt32(row.Cells["RoleID"].Value);
                cboRole.SelectedIndex = (roleId == 1) ? 0 : 1;

                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        // 3. Sự kiện bấm nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tài khoản và Mật khẩu!");
                return;
            }

            var acc = new ElectroManagement.Models.Account()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                // Lấy RoleID: Nếu chọn "Admin" (index 0) thì RoleID = 1, ngược lại = 2
                RoleID = cboRole.SelectedIndex == 0 ? 1 : 2,
                IsActive = chkIsActive.Checked
            };

            if (accountController.AddAccount(acc))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Load lại bảng
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Tài khoản có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Sự kiện bấm nút Cập nhật (Sửa)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để cập nhật!");
                return;
            }

            var acc = new ElectroManagement.Models.Account()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                RoleID = cboRole.SelectedIndex == 0 ? 1 : 2,
                IsActive = chkIsActive.Checked
            };

            if (accountController.UpdateAccount(acc))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Sự kiện bấm nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiện hộp thoại hỏi lại cho chắc chắn
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{txtUsername.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                if (accountController.DeleteAccount(txtUsername.Text))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click(sender, e); // Xóa xong thì tự động làm mới lại form
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Có thể tài khoản này đang được sử dụng ở bảng khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. Sự kiện bấm nút Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            txtUsername.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = 0; // Trả về Admin mặc định
            chkIsActive.Checked = true;

            // Đưa con trỏ chuột quay lại ô Tài khoản
            txtUsername.Focus();

            // Tải lại danh sách dưới bảng
            LoadData();
        }
    }
}