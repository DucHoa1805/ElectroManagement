using ElectroManagement.Controllers.Products;
using ElectroManagement.Models.ProductEntities; // Đừng quên thêm dòng này để dùng class Brand
using System;
using System.Data;
using System.Windows.Forms;

namespace ElectroManagement.Views.Products
{
    public partial class frmBrand : Form
    {
        BrandController controller = new BrandController();
        int selectedId = -1;

        public frmBrand()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgvBrand.DataSource = controller.GetAll();
            if (dgvBrand.Columns["BrandID"] != null) dgvBrand.Columns["BrandID"].Visible = false;
            dgvBrand.Columns["BrandName"].HeaderText = "Tên nhãn hàng";
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBrand.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["BrandID"].Value);
                txtBrandName.Text = row.Cells["BrandName"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrandName.Text)) return;

            // TẠO OBJECT MODEL TRƯỚC KHI GỬI
            Brand b = new Brand { BrandName = txtBrandName.Text };

            controller.Add(b); // Gửi nguyên object b

            LoadData();
            txtBrandName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId != -1 && !string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                // TẠO OBJECT MODEL VỚI ĐỦ ID VÀ NAME
                Brand b = new Brand
                {
                    BrandID = selectedId,
                    BrandName = txtBrandName.Text
                };

                controller.Update(b); // Gửi nguyên object b

                LoadData();
                txtBrandName.Clear();
                selectedId = -1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) return;
            try
            {
                // Xóa vẫn dùng ID là chuẩn nhất
                controller.Delete(selectedId);
                LoadData();
                txtBrandName.Clear();
                selectedId = -1;
            }
            catch
            {
                MessageBox.Show("Không thể xóa hãng này vì đã có sản phẩm thuộc hãng này!");
            }
        }
    }
}