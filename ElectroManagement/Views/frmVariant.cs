using System;
using System.Windows.Forms;
using ElectroManagement.Controllers;
using ElectroManagement.Models; // Thêm using này

namespace ElectroManagement.Views
{
    public partial class frmVariant : Form
    {
        private int _productId;
        private VariantController controller = new VariantController();
        private int selectedVariantId = -1;

        public frmVariant(int productId, string productName)
        {
            InitializeComponent();
            this._productId = productId;
            this.Text = "Biến thể sản phẩm: " + productName;
            LoadData();
        }

        private void LoadData()
        {
            dgvVariant.DataSource = controller.GetByProductId(_productId);

            if (dgvVariant.Columns["VariantID"] != null) dgvVariant.Columns["VariantID"].Visible = false;
            if (dgvVariant.Columns["ProductID"] != null) dgvVariant.Columns["ProductID"].Visible = false;

            dgvVariant.Columns["SKU"].HeaderText = "Mã SKU";
            dgvVariant.Columns["Color"].HeaderText = "Màu sắc";
            dgvVariant.Columns["Storage"].HeaderText = "Dung lượng";
            dgvVariant.Columns["Price"].HeaderText = "Giá bán";
            dgvVariant.Columns["Quantity"].HeaderText = "Số lượng";
        }

        private void dgvVariant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVariant.Rows[e.RowIndex];
                selectedVariantId = Convert.ToInt32(row.Cells["VariantID"].Value);

                txtSKU.Text = row.Cells["SKU"].Value?.ToString();
                txtColor.Text = row.Cells["Color"].Value?.ToString(); // Sửa từ label10 thành txtColor
                txtStorage.Text = row.Cells["Storage"].Value?.ToString();

                nmrPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
                nmrQuantity.Value = Convert.ToDecimal(row.Cells["Quantity"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show("Vui lòng nhập mã SKU!");
                return;
            }

            // Dùng Model ProductVariant cực kỳ gọn
            ProductVariant v = new ProductVariant
            {
                ProductID = _productId,
                SKU = txtSKU.Text,
                Color = txtColor.Text, // Dùng TextBox
                Storage = txtStorage.Text,
                Price = nmrPrice.Value,
                Quantity = (int)nmrQuantity.Value
            };

            controller.Add(v); // Controller của bạn nên nhận vào (ProductVariant v)
            LoadData();
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVariantId == -1)
            {
                MessageBox.Show("Vui lòng chọn một biến thể để sửa!");
                return;
            }

            ProductVariant v = new ProductVariant
            {
                VariantID = selectedVariantId,
                SKU = txtSKU.Text,
                Color = txtColor.Text,
                Storage = txtStorage.Text,
                Price = nmrPrice.Value,
                Quantity = (int)nmrQuantity.Value
            };

            controller.Update(v);
            LoadData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVariantId == -1) return;

            var result = MessageBox.Show("Bạn có chắc muốn xóa biến thể này?", "Xác nhận",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                controller.Delete(selectedVariantId);
                LoadData();
                ClearInput();
            }
        }

        private void ClearInput()
        {
            selectedVariantId = -1;
            txtSKU.Clear();
            txtColor.Clear(); 
            txtStorage.Clear();
            nmrPrice.Value = 0;
            nmrQuantity.Value = 0;
            txtSKU.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}