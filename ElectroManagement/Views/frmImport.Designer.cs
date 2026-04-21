namespace ElectroManagement.Views
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
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            this.lblProductVariant.AutoSize = true;
            this.lblProductVariant.Location = new System.Drawing.Point(20, 20);
            this.lblProductVariant.Name = "lblProductVariant";
            this.lblProductVariant.Size = new System.Drawing.Size(120, 16);
            this.lblProductVariant.TabIndex = 0;
            this.lblProductVariant.Text = "Sản phẩm/ Phân loại:";

            this.cboProductVariant.FormattingEnabled = true;
            this.cboProductVariant.Location = new System.Drawing.Point(150, 20);
            this.cboProductVariant.Name = "cboProductVariant";
            this.cboProductVariant.Size = new System.Drawing.Size(250, 24);
            this.cboProductVariant.TabIndex = 1;

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 60);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(74, 16);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Số lượng:";

            this.numQuantity.Location = new System.Drawing.Point(150, 60);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(250, 22);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 100);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(60, 16);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Ghi chú:";

            this.txtNotes.Location = new System.Drawing.Point(150, 100);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 80);
            this.txtNotes.TabIndex = 5;

            this.btnSave.Location = new System.Drawing.Point(200, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(290, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cboProductVariant);
            this.Controls.Add(this.lblProductVariant);
            this.Name = "frmImport";
            this.Text = "Nhập Kho";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
