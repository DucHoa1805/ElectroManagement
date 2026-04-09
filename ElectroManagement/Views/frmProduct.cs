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
        int selectedId = -1;

        public frmProduct()
        {

            InitializeComponent();
            LoadData();
        }

      

        void LoadData()
        {
            dgvProduct.DataSource = controller.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProductName = txtName.Text,
                CategoryID = int.Parse(txtCategory.Text),
                BrandID = int.Parse(txtBrand.Text),
                Description = txtDesc.Text
            };

            controller.Add(p);
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) return;

            Product p = new Product()
            {
                ProductID = selectedId,
                ProductName = txtName.Text,
                CategoryID = int.Parse(txtCategory.Text),
                BrandID = int.Parse(txtBrand.Text),
                Description = txtDesc.Text
            };

            controller.Update(p);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn dòng nào chưa (phòng trường hợp bấm nút khi chưa chọn)
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hiện hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa mục này không? Thao tác này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // 3. Chỉ thực hiện khi người dùng chọn 'Yes'
            if (result == DialogResult.Yes)
            {
                controller.Delete(selectedId);
                LoadData();

                // Reset lại selectedId để tránh xóa nhầm lần nữa khi bấm nút liên tiếp
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
                txtCategory.Text = row.Cells["CategoryID"].Value.ToString();
                txtBrand.Text = row.Cells["BrandID"].Value.ToString();
                txtDesc.Text = row.Cells["Description"].Value.ToString();
            }
        }
    }
}