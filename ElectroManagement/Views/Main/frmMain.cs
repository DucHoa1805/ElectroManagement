using ElectroManagement.Helpers;
using ElectroManagement.Views.Auth;
using ElectroManagement.Views.Products; // Chứa frmProduct, frmBrand...
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectroManagement.Views.Main
{
    public partial class frmMain : Form
    {
        private Form activeForm = null;

        public frmMain()
        {
            InitializeComponent();

            // Ép buộc giao diện lấp đầy toàn màn hình để tránh bị lỗi hiển thị
            // (Nếu pnlHeader báo lỗi đỏ, có thể bỏ comment dòng đó đi vì Designer đã xử lý)
            // pnlHeader.Dock = DockStyle.Top; 
            pnlContent.Dock = DockStyle.Fill;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // SỬA LỖI: Bỏ dấu ngoặc () vì IsLoggedIn là một Property (biến) trong file Session.cs
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi sử dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #region XỬ LÝ SỰ KIỆN CLICK MENU (Đã đổi tên khớp với MenuStrip)

        // Nhấn vào "Quản lý Sản phẩm"
        private void tsmProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProduct());
        }

        // Nhấn vào "Danh mục sản phẩm"
        private void tsmCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategory());
        }

        // Nhấn vào "Nhãn hàng"
        private void tsmBrand_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBrand());
        }

        // LƯU Ý: Nếu bạn có thêm frmSupplier hay frmOrder, hãy tạo thêm sự kiện tương tự nhé.

        #endregion

        // Nhấn vào nút "Đăng xuất"
        private void tsmLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.Logout();
                this.Close(); // Đóng frmMain, nếu bạn code chuẩn ở Program.cs hoặc Login thì nó sẽ hiện lại màn hình Login.
            }
        }
    }
}