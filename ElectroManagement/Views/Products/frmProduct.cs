using ElectroManagement.Controllers.Products;
using ElectroManagement.Models.ProductEntities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElectroManagement.Views.Products
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
            StyleUI();
            LoadComboBox();
            LoadData();
        }

        // ================= LOAD =================
        void LoadComboBox()
        {
            try
            {
                cboCategory.DataSource = categoryController.GetAll();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";
                cboCategory.SelectedIndex = -1;

                cboBrand.DataSource = brandController.GetAll();
                cboBrand.DisplayMember = "BrandName";
                cboBrand.ValueMember = "BrandID";
                cboBrand.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        void LoadData()
        {
            dgvProduct.AutoGenerateColumns = true;
            dgvProduct.DataSource = controller.GetAllView();

            // Ẩn ID cho đẹp
            HideColumn("ProductID");
            HideColumn("CategoryID");
            HideColumn("BrandID");
        }

        void HideColumn(string name)
        {
            if (dgvProduct.Columns[name] != null)
                dgvProduct.Columns[name].Visible = false;
        }

        // ================= UI =================
        private void StyleUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10);

            StyleGroupBox(groupBox1);
            StyleGroupBox(groupBox2);

            StyleButton(btnAdd, Color.FromArgb(40, 167, 69));
            StyleButton(btnUpdate, Color.FromArgb(0, 123, 255));
            StyleButton(btnDelete, Color.FromArgb(220, 53, 69));
            StyleButton(btnClear, Color.Gray);

            StyleButton(btnManageCategory, Color.DarkOrange);
            StyleButton(btnManageBrand, Color.MediumPurple);
            StyleButton(btnManageVariant, Color.Teal);

            txtName.Font = txtDesc.Font =
            cboCategory.Font = cboBrand.Font =
            new Font("Segoe UI", 10);

            StyleDataGridView();
        }

        private void StyleGroupBox(GroupBox gb)
        {
            gb.BackColor = Color.White;
            gb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => btn.BackColor = color;
        }

        private void StyleDataGridView()
        {
            dgvProduct.BackgroundColor = Color.White;
            dgvProduct.BorderStyle = BorderStyle.None;
            dgvProduct.EnableHeadersVisualStyles = false;

            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvProduct.RowTemplate.Height = 30;
        }

        // ================= VALIDATION =================
        bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn danh mục!");
                return false;
            }

            if (cboBrand.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn nhãn hàng!");
                return false;
            }

            return true;
        }

        // ================= CRUD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                Product p = new Product()
                {
                    ProductName = txtName.Text,
                    CategoryID = (int)cboCategory.SelectedValue,
                    BrandID = (int)cboBrand.SelectedValue,
                    Description = txtDesc.Text
                };

                controller.Add(p);
                LoadData();
                ClearInputs();

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Chọn sản phẩm để sửa!");
                return;
            }

            if (!ValidateInput()) return;

            Product p = new Product()
            {
                ProductID = selectedId,
                ProductName = txtName.Text,
                CategoryID = (int)cboCategory.SelectedValue,
                BrandID = (int)cboBrand.SelectedValue,
                Description = txtDesc.Text
            };

            controller.Update(p);
            LoadData();
            ClearInputs();

            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Chọn dòng để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.Delete(selectedId);
                LoadData();
                ClearInputs();

                MessageBox.Show("Đã xóa!");
            }
        }

        // ================= EVENT =================
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProduct.Rows[e.RowIndex].IsNewRow) return;

            var row = dgvProduct.Rows[e.RowIndex];

            selectedId = Convert.ToInt32(row.Cells["ProductID"].Value);
            txtName.Text = row.Cells["ProductName"].Value.ToString();
            txtDesc.Text = row.Cells["Description"]?.Value?.ToString() ?? "";

            cboCategory.SelectedValue = row.Cells["CategoryID"].Value;
            cboBrand.SelectedValue = row.Cells["BrandID"].Value;
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            new frmCategory().ShowDialog();
            LoadComboBox();
        }

        private void btnManageBrand_Click(object sender, EventArgs e)
        {
            new frmBrand().ShowDialog();
            LoadComboBox();
        }

        private void btnManageVariant_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Chọn sản phẩm trước!");
                return;
            }

            new frmVariant(selectedId, txtName.Text).ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        void ClearInputs()
        {
            selectedId = -1;

            txtName.Clear();
            txtDesc.Clear();

            cboCategory.SelectedIndex = -1;
            cboBrand.SelectedIndex = -1;

            dgvProduct.ClearSelection();
            txtName.Focus();
        }
    }
}