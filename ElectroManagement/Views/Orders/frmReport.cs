using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ElectroManagement.Controllers.Orders;
using ElectroManagement.Models.Orders;
// Sử dụng thư viện ClosedXML đã cài đặt thành công
using ClosedXML.Excel;

namespace ElectroManagement.Views.Orders
{
    public partial class frmReport : Form
    {
        private readonly ReportController _ctrl = new ReportController();

        public frmReport()
        {
            InitializeComponent();
            // Đảm bảo các nút được gán đúng sự kiện
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
        }

        // 1. NÚT XEM BÁO CÁO
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _ctrl.GetRevenueReport(dtpFromDate.Value, dtpToDate.Value);
                dgvReportData.DataSource = data;

                // Tính tổng doanh thu bằng LINQ
                decimal total = data?.Sum(x => x.TotalAmount) ?? 0;
                lblTotalRevenue.Text = string.Format("{0:N0} VND", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. NÚT XUẤT EXCEL
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
                    ExportWithClosedXML(dgvReportData, saveFile.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý xuất dữ liệu bằng ClosedXML (Thay thế cho Interop cũ)
        private void ExportWithClosedXML(DataGridView dgv, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                // Tạo một trang tính mới
                var worksheet = workbook.Worksheets.Add("Doanh Thu");

                // 1. Xuất tiêu đề cột
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    var cell = worksheet.Cell(1, i + 1);
                    cell.Value = dgv.Columns[i].HeaderText;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // 2. Đổ dữ liệu từ DataGridView
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        // i + 2 vì hàng 1 là tiêu đề, Excel bắt đầu từ index 1
                        worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Tự động căn chỉnh độ rộng cột theo nội dung
                worksheet.Columns().AdjustToContents();

                // Lưu file
                workbook.SaveAs(fileName);
            }
        }
    }
}