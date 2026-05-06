namespace ElectroManagement.Views.Inventory
{
    partial class frmInventory
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
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportOrder = new System.Windows.Forms.Button();
            this.dgvPendingOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(12, 276);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(934, 330);
            this.dgvHistory.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(10, 25);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 30);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập Kho Lẻ";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(120, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất Kho Lẻ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(230, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm Mới Trắng";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnViewStock
            // 
            this.btnViewStock = new System.Windows.Forms.Button();
            this.btnViewStock.Location = new System.Drawing.Point(340, 25);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(120, 30);
            this.btnViewStock.TabIndex = 3;
            this.btnViewStock.Text = "Xem Tồn Kho";
            this.btnViewStock.UseVisualStyleBackColor = true;
            this.btnViewStock.Click += new System.EventHandler(this.btnViewStock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnViewStock);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập/Xuất lẻ (Phụ)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportOrder);
            this.groupBox2.Controls.Add(this.dgvPendingOrders);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(934, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ĐƠN HÀNG ĐÃ THANH TOÁN (CHỜ XUẤT KHO)";
            // 
            // btnExportOrder
            // 
            this.btnExportOrder.BackColor = System.Drawing.Color.LightGreen;
            this.btnExportOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportOrder.Location = new System.Drawing.Point(803, 77);
            this.btnExportOrder.Name = "btnExportOrder";
            this.btnExportOrder.Size = new System.Drawing.Size(110, 45);
            this.btnExportOrder.TabIndex = 1;
            this.btnExportOrder.Text = "XUẤT KHO\r\nĐƠN HÀNG";
            this.btnExportOrder.UseVisualStyleBackColor = false;
            this.btnExportOrder.Click += new System.EventHandler(this.btnExportOrder_Click);
            // 
            // dgvPendingOrders
            // 
            this.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingOrders.Location = new System.Drawing.Point(10, 25);
            this.dgvPendingOrders.Name = "dgvPendingOrders";
            this.dgvPendingOrders.ReadOnly = true;
            this.dgvPendingOrders.RowHeadersWidth = 51;
            this.dgvPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingOrders.Size = new System.Drawing.Size(790, 150);
            this.dgvPendingOrders.TabIndex = 0;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInventory";
            this.Text = "Quản Lý Kho Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvHistory;
        public System.Windows.Forms.Button btnImport;
        public System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnViewStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPendingOrders;
        private System.Windows.Forms.Button btnExportOrder;
    }
}
