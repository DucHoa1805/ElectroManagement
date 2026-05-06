using ElectroManagement.Controllers.Inventory;
using System;
using System.Windows.Forms;

namespace ElectroManagement.Views.Inventory
{
    public partial class frmImport : Form
    {
        InventoryController controller = new InventoryController();
        public string Mode = "Import";

        public frmImport(string mode = "Import")
        {
            InitializeComponent();
            Mode = mode;
            this.Text = (mode == "Import") ? "Nhập Kho" : "Xuất Kho";
            LoadProductVariants();
        }

        void LoadProductVariants()
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = ElectroManagement.Database.DatabaseHelper.GetConnection())
                {
                    string query = string.Empty;

                    if (Mode == "Import")
                    {
                        query = @"SELECT pv.VariantID, p.ProductID, p.ProductName, pv.SKU, pv.Color, pv.Storage, pv.Price,
                                 (p.ProductName + ' - ' + ISNULL(pv.Color, '') + ' - ' + ISNULL(pv.Storage, '')) AS DisplayName
                                 FROM ProductVariants pv 
                                 INNER JOIN Products p ON pv.ProductID = p.ProductID";
                    }
                    else
                    {
                        query = @"SELECT pv.VariantID, p.ProductID, p.ProductName, pv.SKU, pv.Color, pv.Storage, pv.Price, pv.Quantity,
                                 (p.ProductName + ' - ' + ISNULL(pv.Color, '') + ' - ' + ISNULL(pv.Storage, '') + ' (Kho: ' + CAST(pv.Quantity AS NVARCHAR) + ')') AS DisplayName
                                 FROM ProductVariants pv 
                                 INNER JOIN Products p ON pv.ProductID = p.ProductID
                                 WHERE pv.Quantity > 0";
                    }

                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);

                    cboProductVariant.DataSource = dt;
                    cboProductVariant.DisplayMember = "DisplayName";
                    cboProductVariant.ValueMember = "VariantID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProductVariant.SelectedValue == null || cboProductVariant.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!");
                    return;
                }

                if (numQuantity.Value <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!");
                    return;
                }

                int variantID = Convert.ToInt32(cboProductVariant.SelectedValue);
                int quantity = Convert.ToInt32(numQuantity.Value);

                dynamic transactionData = new System.Dynamic.ExpandoObject();
                transactionData.VariantID = variantID;
                transactionData.ChangeQuantity = quantity;

                if (Mode == "Import")
                {
                    controller.ImportStock(transactionData);
                    MessageBox.Show("Nhập kho thành công!");
                }
                else
                {
                    controller.ExportStock(transactionData);
                    MessageBox.Show("Xuất kho thành công!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
