using System;
using System.Windows.Forms;
using ElectroManagement.Controllers.Auth;
using ElectroManagement.Models.AuthEntities;
using ElectroManagement.Helpers;             // Thêm để dùng class Session
using ElectroManagement.Views.Main;        // Thêm để gọi được frmMain

namespace ElectroManagement.Views.Auth
{
    public partial class frmLogin : Form
    {
        private AuthController _authController;

        public frmLogin()
        {
            InitializeComponent();
            _authController = new AuthController();

            // Đăng ký sự kiện (Nếu bạn đã gán trong Designer thì có thể bỏ qua dòng này)
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // 2. Gọi hàm Login từ Controller
            User loggedInUser = _authController.Login(username, password);

            // 3. Xử lý kết quả
            if (loggedInUser != null)
            {
                // QUAN TRỌNG: Lưu thông tin vào Session trước khi mở Main
                Session.Login(loggedInUser);

                MessageBox.Show($"Đăng nhập thành công! Chào mừng {loggedInUser.Username}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form login đi
                this.Hide();

                // Mở main form
                frmMain mainForm = new frmMain();
                mainForm.ShowDialog();

                // Khi main đóng, tắt hẳn app
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản đã bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}