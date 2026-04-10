using System;
using System.Windows.Forms;
using ElectroManagement.Controllers;
using ElectroManagement.Models; // Quan trọng để dùng class Category

namespace ElectroManagement.Views
{
    public partial class frmCategory : Form
    {
        CategoryController controller = new CategoryController();
        int selectedId = -1;

        public frmCategory()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgvCategory.DataSource = controller.GetAll();

            if (dgvCategory.Columns["CategoryID"] != null)
                dgvCategory.Columns["CategoryID"].Visible = false;

            dgvCategory.Columns["CategoryName"].HeaderText = "Tên danh mục";
            dgvCategory.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
                return;
            }

            // TẠO OBJECT MODEL
            Category cat = new Category { CategoryName = txtCategoryName.Text };

            // TRUYỀN OBJECT VÀO CONTROLLER
            controller.Add(cat);

            LoadData();
            txtCategoryName.Clear();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text)) return;

            // TẠO OBJECT MODEL VỚI ID VÀ NAME MỚI
            Category cat = new Category
            {
                CategoryID = selectedId,
                CategoryName = txtCategoryName.Text
            };

            // TRUYỀN OBJECT VÀO CONTROLLER
            controller.Update(cat);

            LoadData();
            selectedId = -1;
            txtCategoryName.Clear();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) return;

            var result = MessageBox.Show("Xóa danh mục này có thể ảnh hưởng đến sản phẩm. Bạn chắc chứ?",
                                       "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Xóa vẫn dùng ID là hợp lý nhất
                controller.Delete(selectedId);

                LoadData();
                selectedId = -1;
                txtCategoryName.Clear();
                MessageBox.Show("Đã xóa danh mục!");
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }
    }
}