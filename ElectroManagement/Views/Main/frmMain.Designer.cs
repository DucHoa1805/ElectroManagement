namespace ElectroManagement.Views.Main
{
    partial class frmMain
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
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.report = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.historyOder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWarranty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.pnlHeader.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(267, 86);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "⚡ ELECTROSHOP Admin";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblUserInfo.Location = new System.Drawing.Point(0, 86);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(267, 30);
            this.lblUserInfo.TabIndex = 2;
            this.lblUserInfo.Text = "Xin chào, ";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.msMain);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(267, 814);
            this.pnlHeader.TabIndex = 0;
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.Color.DodgerBlue;
            this.report.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.report.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.report.Name = "report";
            this.report.Padding = new System.Windows.Forms.Padding(15);
            this.report.Size = new System.Drawing.Size(246, 57);
            this.report.Text = "BÁO CÁO DOANH THU";
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // tsmBrand
            // 
            this.tsmBrand.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmBrand.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Padding = new System.Windows.Forms.Padding(15);
            this.tsmBrand.Size = new System.Drawing.Size(246, 57);
            this.tsmBrand.Text = "NHÃN HÀNG";
            this.tsmBrand.Click += new System.EventHandler(this.tsmBrand_Click);
            // 
            // tsmCategory
            // 
            this.tsmCategory.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmCategory.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmCategory.Name = "tsmCategory";
            this.tsmCategory.Padding = new System.Windows.Forms.Padding(15);
            this.tsmCategory.Size = new System.Drawing.Size(246, 57);
            this.tsmCategory.Text = "DANH MỤC SẢN PHẢM";
            this.tsmCategory.Click += new System.EventHandler(this.tsmCategory_Click);
            // 
            // tsmProduct
            // 
            this.tsmProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmProduct.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmProduct.Name = "tsmProduct";
            this.tsmProduct.Padding = new System.Windows.Forms.Padding(15);
            this.tsmProduct.Size = new System.Drawing.Size(246, 57);
            this.tsmProduct.Text = "QUẢN LÝ SẢN PHẨM";
            this.tsmProduct.Click += new System.EventHandler(this.tsmProduct_Click);
            // 
            // historyOder
            // 
            this.historyOder.BackColor = System.Drawing.Color.DodgerBlue;
            this.historyOder.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.historyOder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.historyOder.Name = "historyOder";
            this.historyOder.Padding = new System.Windows.Forms.Padding(15);
            this.historyOder.Size = new System.Drawing.Size(246, 57);
            this.historyOder.Text = "LỊCH SỬ ĐƠN HÀNG";
            this.historyOder.Click += new System.EventHandler(this.historyOder_Click);
            // 
            // tsmOrder
            // 
            this.tsmOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmOrder.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmOrder.Name = "tsmOrder";
            this.tsmOrder.Padding = new System.Windows.Forms.Padding(15);
            this.tsmOrder.Size = new System.Drawing.Size(246, 57);
            this.tsmOrder.Text = "ĐƠN HÀNG";
            this.tsmOrder.Click += new System.EventHandler(this.tsmOrder_Click);
            // 
            // tsmWarranty
            // 
            this.tsmWarranty.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmWarranty.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmWarranty.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmWarranty.Name = "tsmWarranty";
            this.tsmWarranty.Padding = new System.Windows.Forms.Padding(15);
            this.tsmWarranty.Size = new System.Drawing.Size(246, 57);
            this.tsmWarranty.Text = "NHẬT KÝ HỆ THỐNG";
            this.tsmWarranty.Click += new System.EventHandler(this.tsmWarranty_Click);
            // 
            // tsmStaff
            // 
            this.tsmStaff.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmStaff.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmStaff.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmStaff.Name = "tsmStaff";
            this.tsmStaff.Padding = new System.Windows.Forms.Padding(15);
            this.tsmStaff.Size = new System.Drawing.Size(246, 57);
            this.tsmStaff.Text = "QUẢN LÝ NGƯỜI DÙNG";
            this.tsmStaff.Click += new System.EventHandler(this.tsmStaff_Click);
            // 
            // tsmInventory
            // 
            this.tsmInventory.BackColor = System.Drawing.Color.DodgerBlue;
            this.tsmInventory.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.tsmInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmInventory.Name = "tsmInventory";
            this.tsmInventory.Padding = new System.Windows.Forms.Padding(15);
            this.tsmInventory.Size = new System.Drawing.Size(246, 57);
            this.tsmInventory.Text = "NHẬP XUẤT KHO";
            this.tsmInventory.Click += new System.EventHandler(this.tsmInventory_Click);
            // 
            // tsmLogout
            // 
            this.tsmLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmLogout.BackColor = System.Drawing.Color.Red;
            this.tsmLogout.ForeColor = System.Drawing.Color.White;
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Padding = new System.Windows.Forms.Padding(20);
            this.tsmLogout.Size = new System.Drawing.Size(246, 67);
            this.tsmLogout.Text = "🚪 Đăng xuất";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.msMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.msMain.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.report,
            this.tsmBrand,
            this.tsmCategory,
            this.tsmProduct,
            this.historyOder,
            this.tsmOrder,
            this.tsmWarranty,
            this.tsmStaff,
            this.tsmInventory,
            this.tsmLogout});
            this.msMain.Location = new System.Drawing.Point(0, 116);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.msMain.Size = new System.Drawing.Size(267, 698);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(267, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1312, 814);
            this.pnlContent.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 814);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý ElectroShop Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem report;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmProduct;
        private System.Windows.Forms.ToolStripMenuItem historyOder;
        private System.Windows.Forms.ToolStripMenuItem tsmOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmWarranty;
        private System.Windows.Forms.ToolStripMenuItem tsmStaff;
        private System.Windows.Forms.ToolStripMenuItem tsmInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
    }
}