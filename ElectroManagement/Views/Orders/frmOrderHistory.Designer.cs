namespace ElectroManagement.Views.Orders
{
    partial class frmOrderHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrderHistory = new System.Windows.Forms.DataGridView();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            this.panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.MidnightBlue;
            this.panTop.Controls.Add(this.btnRefresh);
            this.panTop.Controls.Add(this.lblTitle);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(800, 70);
            this.panTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH SỬ ĐƠN HÀNG";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(670, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvOrderHistory
            // 
            this.dgvOrderHistory.AllowUserToAddRows = false;
            this.dgvOrderHistory.AllowUserToDeleteRows = false;
            this.dgvOrderHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvOrderHistory.Location = new System.Drawing.Point(0, 70);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.ReadOnly = true;
            this.dgvOrderHistory.RowHeadersWidth = 51;
            this.dgvOrderHistory.RowTemplate.Height = 35;
            this.dgvOrderHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderHistory.Size = new System.Drawing.Size(800, 380);
            this.dgvOrderHistory.TabIndex = 1;
            // Thêm nút xem chi tiết
            System.Windows.Forms.DataGridViewButtonColumn btnView = new System.Windows.Forms.DataGridViewButtonColumn();
            btnView.HeaderText = "Chi tiết";
            btnView.Text = "Chi tiết >>";
            btnView.UseColumnTextForButtonValue = true;
            btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvOrderHistory.Columns.Add(btnView);
            this.dgvOrderHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderHistory_CellContentClick);
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOrderHistory);
            this.Controls.Add(this.panTop);
            this.Name = "frmOrderHistory";
            this.Text = "Lịch sử đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvOrderHistory;
    }
}
