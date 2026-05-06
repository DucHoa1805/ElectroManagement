using ElectroManagement.Controllers.Inventory;
using System;
using System.Data;
using System.Windows.Forms;
using ElectroManagement.Views.Inventory;

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
                // Tải lịch sử nhập xuất
                DataTable dtHistory = controller.GetAllHistory();
                dgvHistory.DataSource = dtHistory;
                FormatHistoryGrid();

                // Tải danh sách đơn hàng đang chờ xuất kho
                DataTable dtPending = controller.GetPendingExportOrders();
                dgvPendingOrders.DataSource = dtPending;
                FormatPendingOrdersGrid();

                // Thêm sự kiện double click để xem chi tiết đơn hàng trước khi xuất
                dgvPendingOrders.CellDoubleClick -= DgvPendingOrders_CellDoubleClick;
                dgvPendingOrders.CellDoubleClick += DgvPendingOrders_CellDoubleClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            frmInventoryStock frmStock = new frmInventoryStock();
            frmStock.ShowDialog();
        }

        private void DgvPendingOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderId = Convert.ToInt32(dgvPendingOrders.Rows[e.RowIndex].Cells["OrderID"].Value);
            // Hiển thị form chi tiết đơn hàng giống frmOrderHistory.ShowOrderDetails
            var orderHistoryCtrl = new ElectroManagement.Controllers.Orders.OrderHistoryController();
            DataTable dtDetails = orderHistoryCtrl.GetOrderDetails(orderId);

            Form frmDetail = new Form();
            frmDetail.Text = $"Chi tiết đơn hàng {orderId}";
            frmDetail.Size = new System.Drawing.Size(600, 400);
            frmDetail.StartPosition = FormStartPosition.CenterParent;

            DataGridView dgvDetail = new DataGridView();
            dgvDetail.Dock = DockStyle.Fill;
            dgvDetail.AllowUserToAddRows = false;
            dgvDetail.ReadOnly = true;
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetail.DataSource = dtDetails;

            if (dgvDetail.Columns["UnitPrice"] != null)
                dgvDetail.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";

            frmDetail.Controls.Add(dgvDetail);
            frmDetail.ShowDialog();
        }

        // Đổi tên cột của bảng pending orders sang tiếng Việt mỗi khi format
        private void FormatPendingOrdersGrid()
        {
            if (dgvPendingOrders.Columns.Count == 0) return;

            // Ẩn các cột không cần thiết
            if (dgvPendingOrders.Columns["OrderID"] != null) dgvPendingOrders.Columns["OrderID"].Visible = false;

            // Định dạng tên header
            if (dgvPendingOrders.Columns["CustomerName"] != null) dgvPendingOrders.Columns["CustomerName"].HeaderText = "Tên Khách Hàng";
            if (dgvPendingOrders.Columns["Phone"] != null) dgvPendingOrders.Columns["Phone"].HeaderText = "Số Điện Thoại";
            if (dgvPendingOrders.Columns["TotalAmount"] != null)
            {
                dgvPendingOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvPendingOrders.Columns["TotalAmount"].HeaderText = "Tổng Tiền (VNĐ)";
            }
            if (dgvPendingOrders.Columns["OrderDate"] != null)
            {
                dgvPendingOrders.Columns["OrderDate"].HeaderText = "Ngày Đặt Hàng";
                dgvPendingOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Mở rộng cột để dễ nhìn
            dgvPendingOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvPendingOrders.Columns["CustomerName"] != null)
            {
                dgvPendingOrders.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPendingOrders.Columns["CustomerName"].FillWeight = 150;
            }
        }

        private void FormatHistoryGrid()
        {
            if (dgvHistory.Columns.Count == 0) return;

            // Ẩn các cột không cần thiết
            if (dgvHistory.Columns["TransactionID"] != null) dgvHistory.Columns["TransactionID"].Visible = false;
            if (dgvHistory.Columns["VariantID"] != null) dgvHistory.Columns["VariantID"].Visible = false;

            // Định dạng tên header
            if (dgvHistory.Columns["ProductName"] != null) dgvHistory.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            if (dgvHistory.Columns["ChangeQuantity"] != null) dgvHistory.Columns["ChangeQuantity"].HeaderText = "Số Lượng (Thay đổi)";
            if (dgvHistory.Columns["Type"] != null) dgvHistory.Columns["Type"].HeaderText = "Loại (Nhập/Xuất)";
            if (dgvHistory.Columns["CurrentQuantity"] != null) dgvHistory.Columns["CurrentQuantity"].HeaderText = "Tồn Kho Hiện Tại";
            if (dgvHistory.Columns["CreatedAt"] != null)
            {
                dgvHistory.Columns["CreatedAt"].HeaderText = "Ngày Giao Dịch";
                dgvHistory.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Mở rộng cột để dễ nhìn
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvHistory.Columns["ProductName"] != null)
            {
                dgvHistory.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvHistory.Columns["ProductName"].FillWeight = 200; // Chiếm nhiều diện tích hơn
            }
        }


        private void btnExportOrder_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xuất kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvPendingOrders.CurrentRow.Cells["OrderID"].Value);
            string customerName = dgvPendingOrders.CurrentRow.Cells["CustomerName"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xuất kho cho Đơn hàng #{orderId} (Khách: {customerName})?",
                                                  "Xác nhận xuất kho",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = controller.ExportOrder(orderId);
                if (success)
                {
                    MessageBox.Show("Xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Làm mới lại 2 cái bảng
                }
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
