namespace ElectroManagement.Views.Inventory
{
    partial class frmImport
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
            this.lblProductVariant = new System.Windows.Forms.Label();
            this.cboProductVariant = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            // Panel container to add background color
            System.Windows.Forms.Panel panelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            panelMain.SuspendLayout();
            this.SuspendLayout();

            // Set up Panel
            panelMain.BackColor = System.Drawing.Color.AliceBlue;
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Padding = new System.Windows.Forms.Padding(20);
            
            this.lblProductVariant.AutoSize = true;
            this.lblProductVariant.Location = new System.Drawing.Point(30, 30);
            this.lblProductVariant.Name = "lblProductVariant";
            this.lblProductVariant.Size = new System.Drawing.Size(120, 16);
            this.lblProductVariant.TabIndex = 0;
            this.lblProductVariant.Text = "Sản phẩm/ Phân loại:";
            this.lblProductVariant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductVariant.ForeColor = System.Drawing.Color.DarkSlateBlue;

            this.cboProductVariant.FormattingEnabled = true;
            this.cboProductVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductVariant.Location = new System.Drawing.Point(170, 28);
            this.cboProductVariant.Name = "cboProductVariant";
            this.cboProductVariant.Size = new System.Drawing.Size(250, 24);
            this.cboProductVariant.TabIndex = 1;
            this.cboProductVariant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductVariant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboProductVariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(30, 75);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(74, 16);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.DarkSlateBlue;

            this.numQuantity.Location = new System.Drawing.Point(170, 75);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(250, 22);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(30, 120);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(60, 16);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Ghi chú:";
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.DarkSlateBlue;

            this.txtNotes.Location = new System.Drawing.Point(170, 120);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 80);
            this.txtNotes.TabIndex = 5;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.btnSave.Location = new System.Drawing.Point(230, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(330, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to panel
            panelMain.Controls.Add(this.btnCancel);
            panelMain.Controls.Add(this.btnSave);
            panelMain.Controls.Add(this.txtNotes);
            panelMain.Controls.Add(this.lblNotes);
            panelMain.Controls.Add(this.numQuantity);
            panelMain.Controls.Add(this.lblQuantity);
            panelMain.Controls.Add(this.cboProductVariant);
            panelMain.Controls.Add(this.lblProductVariant);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 280);
            this.Controls.Add(panelMain);
            this.Name = "frmImport";
            this.Text = "Nhập Kho";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblProductVariant;
        public System.Windows.Forms.ComboBox cboProductVariant;
        private System.Windows.Forms.Label lblQuantity;
        public System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblNotes;
        public System.Windows.Forms.TextBox txtNotes;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
    }
}
