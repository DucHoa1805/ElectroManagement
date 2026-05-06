using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
// Cập nhật đường dẫn namespace mới
using ElectroManagement.Controllers.Report.AuditLog;
using ElectroManagement.Models.Report.AuditLog;
using ClosedXML.Excel;

namespace ElectroManagement.Views.Orders
{
    public partial class frmReport : Form
    {
        private readonly ReportController _ctrl = new ReportController();

        public frmReport()
        {
            InitializeComponent();

            // GỌI HÀM FORMAT BẢNG NGAY KHI KHỞI TẠO FORM
            FormatDataGridView();

            // Gán sự kiện cho các nút
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);

            // Tự động load dữ liệu khi mở Form
            this.Load += new System.EventHandler(this.frmReport_Load);
        }

        /// <summary>
        /// Hàm định dạng DataGridView hiển thị đẹp mắt và chuẩn form báo cáo
        /// </summary>
        private void FormatDataGridView()
        {
            // Tắt tự động tạo cột
            dgvReportData.AutoGenerateColumns = false;
            dgvReportData.Columns.Clear();

            // 1. Cột Mã Đơn
            dgvReportData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderID",
                HeaderText = "Mã Đơn",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 2. Cột Ngày đặt
            dgvReportData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "Thời Gian",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } // Format ngày giờ chuẩn Việt Nam
            });

            // 3. Cột Tổng tiền
            dgvReportData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng Tiền (VNĐ)",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0", // Có dấu phẩy ngăn cách hàng nghìn
                    Alignment = DataGridViewContentAlignment.MiddleRight // Tiền tệ căn phải
                }
            });

            // 4. Cột Trạng thái đơn hàng
            dgvReportData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng Thái Đơn",
                Width = 120
            });

            // 5. Cột Trạng thái thanh toán
            dgvReportData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentStatus",
                HeaderText = "Thanh Toán",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động kéo dài lấp khoảng trống
            });

            // Tùy chỉnh thêm UI cho DataGridView đẹp hơn
            dgvReportData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgvReportData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReportData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvReportData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportData.AllowUserToAddRows = false;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định (đầu tháng đến hiện tại)
            DateTime now = DateTime.Now;
            dtpFromDate.Value = new DateTime(now.Year, now.Month, 1);
            dtpToDate.Value = now;

            LoadDefaultReport();
        }

        private void LoadDefaultReport()
        {
            try
            {
                var data = _ctrl.GetRevenueReport(dtpFromDate.Value, dtpToDate.Value);

                // Gán dữ liệu vào đúng dgvReportData
                dgvReportData.DataSource = data;

                decimal total = data?.Sum(x => x.TotalAmount) ?? 0;
                lblTotalRevenue.Text = string.Format("{0:N0} VND", total);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load dữ liệu ban đầu: " + ex.Message);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadDefaultReport();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvReportData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel Workbook|*.xlsx";
                saveFile.Title = "Chọn nơi lưu file báo cáo";
                saveFile.FileName = "Bao_Cao_Doanh_Thu_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    // Truyền dgvReportData vào hàm Export
                    ExportWithClosedXML(dgvReportData, saveFile.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportWithClosedXML(DataGridView dgv, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Doanh Thu");

                // Tiêu đề cột
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    var cell = worksheet.Cell(1, i + 1);
                    cell.Value = dgv.Columns[i].HeaderText;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Dữ liệu
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
            }
        }
    }
}