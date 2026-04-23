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
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";

            this.btnImport.Location = new System.Drawing.Point(10, 25);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 30);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập Kho";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            this.btnExport.Location = new System.Drawing.Point(120, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất Kho";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.btnRefresh.Location = new System.Drawing.Point(230, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(12, 80);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(760, 360);
            this.dgvHistory.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInventory";
            this.Text = "Quản Lý Kho Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.DataGridView dgvHistory;
        public System.Windows.Forms.Button btnImport;
        public System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
