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
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(15, 25);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập Kho";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(130, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 35);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất Kho Lẻ";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.BackColor = System.Drawing.Color.Goldenrod;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(255, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnViewStock
            // 
            this.btnViewStock = new System.Windows.Forms.Button();
            this.btnViewStock.Location = new System.Drawing.Point(370, 25);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(120, 35);
            this.btnViewStock.TabIndex = 3;
            this.btnViewStock.Text = "Xem Tồn Kho";
            this.btnViewStock.UseVisualStyleBackColor = false;
            this.btnViewStock.BackColor = System.Drawing.Color.DarkCyan;
            this.btnViewStock.ForeColor = System.Drawing.Color.White;
            this.btnViewStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStock.FlatAppearance.BorderSize = 0;
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
            this.groupBox1.Size = new System.Drawing.Size(510, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập/Xuất lẻ (Phụ)";
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportOrder);
            this.groupBox2.Controls.Add(this.dgvPendingOrders);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(934, 175);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ĐƠN HÀNG ĐÃ THANH TOÁN (CHỜ XUẤT KHO)";
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            // 
            // btnExportOrder
            // 
            this.btnExportOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportOrder.ForeColor = System.Drawing.Color.White;
            this.btnExportOrder.Location = new System.Drawing.Point(825, 70);
            this.btnExportOrder.Name = "btnExportOrder";
            this.btnExportOrder.Size = new System.Drawing.Size(90, 45);
            this.btnExportOrder.TabIndex = 1;
            this.btnExportOrder.Text = "XUẤT";
            this.btnExportOrder.UseVisualStyleBackColor = false;
            this.btnExportOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportOrder.FlatAppearance.BorderSize = 0;
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
            this.dgvPendingOrders.Size = new System.Drawing.Size(800, 140);
            this.dgvPendingOrders.TabIndex = 0;
            this.dgvPendingOrders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPendingOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPendingOrders.AllowUserToAddRows = false;
            this.dgvPendingOrders.AllowUserToDeleteRows = false;
            this.dgvPendingOrders.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPendingOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 620);
            this.BackColor = System.Drawing.Color.AliceBlue;
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
