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
            this.msMain = new System.Windows.Forms.MenuStrip();
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(280, 80);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "⚡ ELECTROSHOP";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUserInfo.Location = new System.Drawing.Point(0, 80);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(280, 40);
            this.lblUserInfo.TabIndex = 2;
            this.lblUserInfo.Text = "Xin chào, Admin";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.msMain);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(280, 814);
            this.pnlHeader.TabIndex = 0;
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.BackColor = System.Drawing.Color.Transparent;
            this.msMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msMain.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.msMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.msMain.Location = new System.Drawing.Point(0, 120);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(0, 15, 0, 10);
            this.msMain.ShowItemToolTips = true;
            this.msMain.Size = new System.Drawing.Size(280, 694);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // report
            // 
            this.report.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.report.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.report.Name = "report";
            this.report.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.report.Size = new System.Drawing.Size(259, 53);
            this.report.Text = "📊  Báo cáo doanh thu";
            this.report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // tsmBrand
            // 
            this.tsmBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmBrand.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmBrand.Size = new System.Drawing.Size(259, 53);
            this.tsmBrand.Text = "🏷️  Nhãn hàng";
            this.tsmBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmBrand.Click += new System.EventHandler(this.tsmBrand_Click);
            // 
            // tsmCategory
            // 
            this.tsmCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmCategory.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmCategory.Name = "tsmCategory";
            this.tsmCategory.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmCategory.Size = new System.Drawing.Size(259, 53);
            this.tsmCategory.Text = "📁  Danh mục sản phẩm";
            this.tsmCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmCategory.Click += new System.EventHandler(this.tsmCategory_Click);
            // 
            // tsmProduct
            // 
            this.tsmProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmProduct.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmProduct.Name = "tsmProduct";
            this.tsmProduct.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmProduct.Size = new System.Drawing.Size(259, 53);
            this.tsmProduct.Text = "📦  Quản lý sản phẩm";
            this.tsmProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmProduct.Click += new System.EventHandler(this.tsmProduct_Click);
            // 
            // historyOder
            // 
            this.historyOder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.historyOder.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.historyOder.Name = "historyOder";
            this.historyOder.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.historyOder.Size = new System.Drawing.Size(259, 53);
            this.historyOder.Text = "📜  Lịch sử đơn hàng";
            this.historyOder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.historyOder.Click += new System.EventHandler(this.historyOder_Click);
            // 
            // tsmOrder
            // 
            this.tsmOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmOrder.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmOrder.Name = "tsmOrder";
            this.tsmOrder.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmOrder.Size = new System.Drawing.Size(259, 53);
            this.tsmOrder.Text = "🛒  Đơn hàng";
            this.tsmOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmOrder.Click += new System.EventHandler(this.tsmOrder_Click);
            // 
            // tsmWarranty
            // 
            this.tsmWarranty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmWarranty.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmWarranty.Name = "tsmWarranty";
            this.tsmWarranty.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmWarranty.Size = new System.Drawing.Size(259, 53);
            this.tsmWarranty.Text = "🛡️  Nhật ký hệ thống";
            this.tsmWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmWarranty.Click += new System.EventHandler(this.tsmWarranty_Click);
            // 
            // tsmStaff
            // 
            this.tsmStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmStaff.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmStaff.Name = "tsmStaff";
            this.tsmStaff.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmStaff.Size = new System.Drawing.Size(259, 53);
            this.tsmStaff.Text = "👥  Quản lý người dùng";
            this.tsmStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmStaff.Click += new System.EventHandler(this.tsmStaff_Click);
            // 
            // tsmInventory
            // 
            this.tsmInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.tsmInventory.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tsmInventory.Name = "tsmInventory";
            this.tsmInventory.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmInventory.Size = new System.Drawing.Size(259, 53);
            this.tsmInventory.Text = "🏭  Nhập xuất kho";
            this.tsmInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmInventory.Click += new System.EventHandler(this.tsmInventory_Click);
            // 
            // tsmLogout
            // 
            this.tsmLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.tsmLogout.ForeColor = System.Drawing.Color.White;
            this.tsmLogout.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.tsmLogout.Size = new System.Drawing.Size(249, 53);
            this.tsmLogout.Text = "🚪 Đăng xuất";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(280, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1299, 814);
            this.pnlContent.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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