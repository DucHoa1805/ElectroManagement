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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWarranty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.msMain);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1579, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.Transparent;
            this.msMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDashboard,
            this.tsmCatalog,
            this.tsmBusiness,
            this.tsmSystem,
            this.tsmLogout});
            this.msMain.Location = new System.Drawing.Point(240, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(13, 25, 0, 0);
            this.msMain.Size = new System.Drawing.Size(1339, 86);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmDashboard
            // 
            this.tsmDashboard.ForeColor = System.Drawing.Color.White;
            this.tsmDashboard.Name = "tsmDashboard";
            this.tsmDashboard.Size = new System.Drawing.Size(123, 61);
            this.tsmDashboard.Text = "📈 Thống kê";
            // 
            // tsmCatalog
            // 
            this.tsmCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProduct,
            this.tsmCategory,
            this.tsmBrand,
            this.tsmInventory,
            this.tsmSupplier});
            this.tsmCatalog.ForeColor = System.Drawing.Color.White;
            this.tsmCatalog.Name = "tsmCatalog";
            this.tsmCatalog.Size = new System.Drawing.Size(167, 61);
            this.tsmCatalog.Text = "📦 Hàng hóa & Kho";
            // 
            // tsmProduct
            // 
            this.tsmProduct.Name = "tsmProduct";
            this.tsmProduct.Size = new System.Drawing.Size(273, 28);
            this.tsmProduct.Text = "🏢 Quản lý Sản phẩm";
            this.tsmProduct.Click += new System.EventHandler(this.tsmProduct_Click);
            // 
            // tsmCategory
            // 
            this.tsmCategory.Name = "tsmCategory";
            this.tsmCategory.Size = new System.Drawing.Size(273, 28);
            this.tsmCategory.Text = "☱ Danh mục sản phẩm";
            this.tsmCategory.Click += new System.EventHandler(this.tsmCategory_Click);
            // 
            // tsmBrand
            // 
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Size = new System.Drawing.Size(273, 28);
            this.tsmBrand.Text = "🔖 Nhãn hàng";
            this.tsmBrand.Click += new System.EventHandler(this.tsmBrand_Click);
            // 
            // tsmInventory
            // 
            this.tsmInventory.Name = "tsmInventory";
            this.tsmInventory.Size = new System.Drawing.Size(273, 28);
            this.tsmInventory.Text = "🏬 Quản lý Tồn kho";
            // 
            // tsmSupplier
            // 
            this.tsmSupplier.Name = "tsmSupplier";
            this.tsmSupplier.Size = new System.Drawing.Size(273, 28);
            this.tsmSupplier.Text = "🚛 Nhà cung cấp";
            // 
            // tsmBusiness
            // 
            this.tsmBusiness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOrder,
            this.tsmCustomer});
            this.tsmBusiness.ForeColor = System.Drawing.Color.White;
            this.tsmBusiness.Name = "tsmBusiness";
            this.tsmBusiness.Size = new System.Drawing.Size(140, 61);
            this.tsmBusiness.Text = "📑 Kinh doanh";
            // 
            // tsmOrder
            // 
            this.tsmOrder.Name = "tsmOrder";
            this.tsmOrder.Size = new System.Drawing.Size(213, 28);
            this.tsmOrder.Text = "📝 Đơn hàng";
            // 
            // tsmCustomer
            // 
            this.tsmCustomer.Name = "tsmCustomer";
            this.tsmCustomer.Size = new System.Drawing.Size(213, 28);
            this.tsmCustomer.Text = "👤 Khách hàng";
            // 
            // tsmSystem
            // 
            this.tsmSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStaff,
            this.tsmWarranty});
            this.tsmSystem.ForeColor = System.Drawing.Color.White;
            this.tsmSystem.Name = "tsmSystem";
            this.tsmSystem.Size = new System.Drawing.Size(124, 61);
            this.tsmSystem.Text = "⚙️ Hệ thống";
            // 
            // tsmStaff
            // 
            this.tsmStaff.Name = "tsmStaff";
            this.tsmStaff.Size = new System.Drawing.Size(275, 28);
            this.tsmStaff.Text = "👮 Nhân viên";
            // 
            // tsmWarranty
            // 
            this.tsmWarranty.Name = "tsmWarranty";
            this.tsmWarranty.Size = new System.Drawing.Size(275, 28);
            this.tsmWarranty.Text = "🛠 Bảo hành & Sửa chữa";
            // 
            // tsmLogout
            // 
            this.tsmLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Size = new System.Drawing.Size(131, 61);
            this.tsmLogout.Text = "🚪 Đăng xuất";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(240, 86);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "⚡ ELECTROSHOP Admin";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.DarkGray;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 86);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1579, 728);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Resize += new System.EventHandler(this.pnlContent_Resize);
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
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.MenuStrip msMain;

        // Định nghĩa các mục menu chính
        private System.Windows.Forms.ToolStripMenuItem tsmDashboard;
        private System.Windows.Forms.ToolStripMenuItem tsmCatalog;
        private System.Windows.Forms.ToolStripMenuItem tsmBusiness;
        private System.Windows.Forms.ToolStripMenuItem tsmSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;

        // Định nghĩa các mục menu con
        private System.Windows.Forms.ToolStripMenuItem tsmProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmStaff;
        private System.Windows.Forms.ToolStripMenuItem tsmWarranty;

        private System.Windows.Forms.Panel pnlContent;
    }
}