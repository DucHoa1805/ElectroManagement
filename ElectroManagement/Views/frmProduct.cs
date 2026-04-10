using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ElectroManagement.Controllers;
using ElectroManagement.Models;

namespace ElectroManagement.Views
{
    public partial class frmProduct : Form
    {
        ProductController controller = new ProductController();
        CategoryController categoryController = new CategoryController();
        BrandController brandController = new BrandController();
        int selectedId = -1;

        public frmProduct()
        {
            InitializeComponent();
            LoadComboBox();
            LoadData();
            // Nếu có ComboBox thì gọi LoadComboBox() ở đây
        }
        // Bạn cần tạo thêm CategoryController và BrandController để lấy dữ liệu nhé
        void LoadComboBox()
        {
            try
            {
                // Nạp cho Danh mục
                cboCategory.DataSource = categoryController.GetAll();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";
                cboCategory.SelectedIndex = -1; // Để mặc định không chọn cái nào lúc mới mở

                // Nạp cho Nhãn hàng
                cboBrand.DataSource = brandController.GetAll();
                cboBrand.DisplayMember = "BrandName";
                cboBrand.ValueMember = "BrandID";
                cboBrand.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Nếu lỗi kết nối DB lúc khởi động, nó sẽ báo ở đây
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        void LoadData()
        {
            // Tự động tạo cột nếu chưa có
            dgvProduct.AutoGenerateColumns = true;
            dgvProduct.DataSource = controller.GetAllView();

            // Ẩn các cột ID đi để giao diện sạch hơn, nhưng code vẫn lấy được giá trị
            if (dgvProduct.Columns["ProductID"] != null) dgvProduct.Columns["ProductID"].Visible = false;
            if (dgvProduct.Columns["CategoryID"] != null) dgvProduct.Columns["CategoryID"].Visible = false;
            if (dgvProduct.Columns["BrandID"] != null) dgvProduct.Columns["BrandID"].Visible = false;

            // Đảm bảo BrandName và CategoryName luôn hiện
            if (dgvProduct.Columns["BrandName"] != null) dgvProduct.Columns["BrandName"].Visible = true;
            if (dgvProduct.Columns["CategoryName"] != null) dgvProduct.Columns["CategoryName"].Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product()
                {
                    ProductName = txtName.Text,

                    // SỬA TẠI ĐÂY: Lấy giá trị ID từ ComboBox thay vì TextBox cũ
                    CategoryID = (int)cboCategory.SelectedValue,
                    BrandID = (int)cboBrand.SelectedValue,

                    Description = txtDesc.Text
                };

                controller.Add(p);
                LoadData();
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProductID = selectedId,
                ProductName = txtName.Text,
                CategoryID = (int)cboCategory.SelectedValue, // Lấy ID cực kỳ an toàn
                BrandID = (int)cboBrand.SelectedValue,
                Description = txtDesc.Text
            };
            controller.Update(p);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa mục này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                controller.Delete(selectedId);
                LoadData();
                selectedId = -1;
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["ProductID"].Value);
                txtName.Text = row.Cells["ProductName"].Value.ToString();

                // Cực kỳ quan trọng: ComboBox sẽ tự nhảy đến đúng tên dựa trên ID ẩn
                cboCategory.SelectedValue = row.Cells["CategoryID"].Value;
                cboBrand.SelectedValue = row.Cells["BrandID"].Value;

                txtDesc.Text = row.Cells["Description"].Value?.ToString() ?? "";
            }
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            f.ShowDialog();

            // QUAN TRỌNG: Nạp lại ComboBox để hiện danh mục mới vừa thêm/sửa
            LoadComboBox();
        }

        private void btnManageBrand_Click(object sender, EventArgs e)
        {
            frmBrand f = new frmBrand();
            f.ShowDialog();

            // QUAN TRỌNG: Nạp lại ComboBox cho Nhãn hàng
            LoadComboBox();
        }

        private void btnManageVariant_Click(object sender, EventArgs e)
        {
            // selectedId là ID sản phẩm bạn lấy được khi Click vào bảng Sản phẩm
            if (selectedId == -1)
            {
                MessageBox.Show("Hãy chọn một sản phẩm ở bảng danh sách trước!");
                return;
            }

            // Truyền ID và Tên sản phẩm sang Form con
            frmVariant f = new frmVariant(selectedId, txtName.Text);
            f.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        void ClearInputs()
        {
            selectedId = -1; // Reset lại ID đã chọn
            txtName.Clear();
            txtDesc.Clear();

            // Reset ComboBox về mục đầu tiên (nếu danh sách có dữ liệu)
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            if (cboBrand.Items.Count > 0) cboBrand.SelectedIndex = 0;

            // Bỏ chọn dòng trong DataGridView (nếu có)
            dgvProduct.ClearSelection();

            // Đưa con trỏ chuột về ô tên sản phẩm để người dùng nhập mới luôn
            txtName.Focus();
        }
    }
}