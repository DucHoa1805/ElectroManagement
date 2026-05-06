using ElectroManagement.Helpers;
using ElectroManagement.Views.Auth;
using ElectroManagement.Views.Products; // Chứa frmProduct, frmBrand...
using System;
using ElectroManagement.Views.Orders; // Chứa frmOrder, frmPayment...
using ElectroManagement.Views.Inventory; // Chứa frmInventory
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

            // Hiển thị tên người dùng sau khi đăng nhập thành công
            lblUserInfo.Text = $"Xin chào, {Session.CurrentUser.Username}";
        }

        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem form này đã đang được mở chưa
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl.GetType() == childForm.GetType())
                {
                    ctrl.BringToFront(); // Đẩy form đó lên trên cùng
                    return; // Thoát ra, không tạo form mới
                }
            }

            // Nếu người dùng không muốn giữ nhiều form, gỡ comment dòng dưới:
            // pnlContent.Controls.Clear(); 

            childForm.TopLevel = false;

            // Cho phép người dùng kéo thả, thu phóng Windows bên trong Main (không cố định)
            childForm.FormBorderStyle = FormBorderStyle.Sizable; 

            // Nếu muốn nhìn thấy thanh tiêu đề trên của form con để user dễ kéo:
            // (Nếu bạn muốn giao diện phẳng thì để FormBorderStyle = FixedSingle hoăc SizableToolWindow)

            // KHÔNG dùng DockStyle
            childForm.Dock = DockStyle.None;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;

            // Xếp lớp các Form mở ra lùi xuống 1 góc nhỏ để dễ nhìn nếu mở nhiều (Cascade)
            int offset = pnlContent.Controls.Count * 25; // Mỗi lần mở tụt xuống 25px
            int x = ((pnlContent.Width - childForm.Width) / 2) + offset - 50; 
            int y = ((pnlContent.Height - childForm.Height) / 2) + offset - 50;

            childForm.Location = new Point(x > 0 ? x : 0, y > 0 ? y : 0);

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
                this.Hide(); // Ẩn frmMain
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); // Hiển thị form đăng nhập
                this.Close(); // Đóng frmMain sau khi form đăng nhập đóng (hoặc đăng nhập thành công)
            }
        }

        private void pnlContent_Resize(object sender, EventArgs e)
        {
            // Bỏ tự động resize căn giữa cứng ngắc, vì giờ ta muốn tự do di chuyển các cửa sổ
        }

        private void tsmOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrder());
        }

        private void tsmInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInventory());
        }

        private void historyOder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrderHistory());
        }

        // --- Menu Quản lý Hệ Thống ---

        private void tsmStaff_Click(object sender, EventArgs e)
        {
            // Quản lý người dùng
            if (Session.CurrentUser == null || Session.CurrentUser.RoleID != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào Quản lý người dùng hoặc chưa đăng nhập hợp lệ!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new ElectroManagement.Views.Account.frmAccount());
        }

        private void tsmWarranty_Click(object sender, EventArgs e)
        {
            // Nhật ký hệ thống
            if (Session.CurrentUser == null || Session.CurrentUser.RoleID != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào Nhật ký hệ thống hoặc chưa đăng nhập hợp lệ!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new ElectroManagement.Views.Report.AuditLog.frmAuditLog());
        }

        private void report_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReport());
        }

       
    }
}