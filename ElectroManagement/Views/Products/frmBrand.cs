using ElectroManagement.Controllers.Products;
using ElectroManagement.Models.ProductEntities;
using System;
using System.Drawing;
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
            StyleUI();
            LoadData();
        }

        // ================= UI =================
        void StyleUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10);

            // Button style
            StyleButton(btnAdd, Color.FromArgb(40, 167, 69));
            StyleButton(btnUpdate, Color.FromArgb(0, 123, 255));
            StyleButton(btnDelete, Color.FromArgb(220, 53, 69));

            // TextBox
            txtBrandName.Font = new Font("Segoe UI", 10);

            // DataGridView
            StyleDataGridView();
        }

        void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => btn.BackColor = color;
        }

        void StyleDataGridView()
        {
            dgvBrand.BackgroundColor = Color.White;
            dgvBrand.BorderStyle = BorderStyle.None;
            dgvBrand.EnableHeadersVisualStyles = false;

            dgvBrand.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgvBrand.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBrand.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvBrand.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvBrand.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvBrand.RowTemplate.Height = 30;
        }

        // ================= DATA =================
        void LoadData()
        {
            dgvBrand.AutoGenerateColumns = true;
            dgvBrand.DataSource = controller.GetAll();

            if (dgvBrand.Columns["BrandID"] != null)
                dgvBrand.Columns["BrandID"].Visible = false;

            if (dgvBrand.Columns["BrandName"] != null)
                dgvBrand.Columns["BrandName"].HeaderText = "Tên nhãn hàng";
        }

        // ================= VALIDATION =================
        bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                MessageBox.Show("Tên nhãn hàng không được để trống!");
                return false;
            }
            return true;
        }

        // ================= EVENT =================
        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvBrand.Rows[e.RowIndex];

            selectedId = Convert.ToInt32(row.Cells["BrandID"].Value);
            txtBrandName.Text = row.Cells["BrandName"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Brand b = new Brand
            {
                BrandName = txtBrandName.Text
            };

            controller.Add(b);
            LoadData();
            ClearForm();

            MessageBox.Show("Thêm thành công!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Chọn nhãn hàng để sửa!");
                return;
            }

            if (!ValidateInput()) return;

            Brand b = new Brand
            {
                BrandID = selectedId,
                BrandName = txtBrandName.Text
            };

            controller.Update(b);
            LoadData();
            ClearForm();

            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Chọn nhãn hàng để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa nhãn hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    controller.Delete(selectedId);
                    LoadData();
                    ClearForm();

                    MessageBox.Show("Đã xóa!");
                }
                catch
                {
                    MessageBox.Show("Không thể xóa vì đã có sản phẩm!");
                }
            }
        }

        void ClearForm()
        {
            selectedId = -1;
            txtBrandName.Clear();
            dgvBrand.ClearSelection();
            txtBrandName.Focus();
        }
    }
}