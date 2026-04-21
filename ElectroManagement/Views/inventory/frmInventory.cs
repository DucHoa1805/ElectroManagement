using ElectroManagement.Controllers.Inventory;
using System;
using System.Data;
using System.Windows.Forms;

namespace ElectroManagement.Views.Inventory
{
    public partial class frmInventory : Form
    {
        InventoryController controller = new InventoryController();

        public frmInventory()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                DataTable dt = controller.GetAllHistory();
                dgvHistory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            frm.ShowDialog();
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport("Export");
            frm.ShowDialog();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
