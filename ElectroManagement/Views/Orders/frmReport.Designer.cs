namespace ElectroManagement.Views.Orders
{
    partial class frmReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dgvReportData = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1125, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(408, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO DOANH THU";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFilter.Controls.Add(this.btnExportExcel);
            this.pnlFilter.Controls.Add(this.btnViewReport);
            this.pnlFilter.Controls.Add(this.dtpToDate);
            this.pnlFilter.Controls.Add(this.lblToDate);
            this.pnlFilter.Controls.Add(this.dtpFromDate);
            this.pnlFilter.Controls.Add(this.lblFromDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 75);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1125, 100);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(844, 25);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(135, 50);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(686, 25);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(135, 50);
            this.btnViewReport.TabIndex = 4;
            this.btnViewReport.Text = "Xem báo cáo";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(450, 38);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(168, 26);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(349, 40);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(81, 20);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(112, 38);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(168, 26);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(22, 40);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 20);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // dgvReportData
            // 
            this.dgvReportData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportData.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportData.Location = new System.Drawing.Point(0, 175);
            this.dgvReportData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReportData.Name = "dgvReportData";
            this.dgvReportData.RowHeadersWidth = 51;
            this.dgvReportData.Size = new System.Drawing.Size(1125, 500);
            this.dgvReportData.TabIndex = 2;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.LightGray;
            this.pnlSummary.Controls.Add(this.lblTotalRevenue);
            this.pnlSummary.Controls.Add(this.lblTotalLabel);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(0, 675);
            this.pnlSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1125, 75);
            this.pnlSummary.TabIndex = 3;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRevenue.Location = new System.Drawing.Point(900, 19);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(103, 38);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 VND";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(698, 22);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(204, 32);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "Tổng doanh thu:";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 750);
            this.Controls.Add(this.dgvReportData);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReport";
            this.Text = "Báo cáo doanh thu";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvReportData;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalLabel;
    }
}