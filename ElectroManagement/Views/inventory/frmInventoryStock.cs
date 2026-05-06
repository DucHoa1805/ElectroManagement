using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ElectroManagement.Controllers.Inventory;

namespace ElectroManagement.Views.Inventory
{
    public partial class frmInventoryStock : Form
    {
        private InventoryController _inventoryController;

        public frmInventoryStock()
        {
            InitializeComponent();
            _inventoryController = new InventoryController();
        }

        private void frmInventoryStock_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void LoadStockData()
        {
            try
            {
                DataTable dtStock = _inventoryController.GetCurrentStock();
                dgvStock.DataSource = dtStock;
                
                CheckLowStock(dtStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckLowStock(DataTable dtStock)
        {
            string lowStockItems = "";
            foreach (DataRow row in dtStock.Rows)
            {
                int quantity = 0;
                if (row["CurrentQuantity"] != DBNull.Value)
                {
                    quantity = Convert.ToInt32(row["CurrentQuantity"]);
                }
                
                if (quantity < 10)
                {
                    lowStockItems += $"- {row["ProductName"].ToString()} (Còn lại: {quantity})\n";
                }
            }

            if (!string.IsNullOrEmpty(lowStockItems))
            {
                MessageBox.Show("Các sản phẩm sau sắp hết hàng (số lượng < 10):\n\n" + lowStockItems + "\n\nVui lòng nhập thêm hàng.", "Cảnh báo hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }
    }
}
