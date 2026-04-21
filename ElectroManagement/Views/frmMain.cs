using System;
using System.Windows.Forms;

namespace ElectroManagement.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory.frmInventory frm = new Inventory.frmInventory();
            frm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Products.frmProduct frm = new Products.frmProduct();
            frm.ShowDialog();
        }
    }
}
