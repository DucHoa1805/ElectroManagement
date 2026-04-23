namespace ElectroManagement.Views.Orders
{
    partial class frmPayment
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
            this.gbPaymentDetails = new System.Windows.Forms.GroupBox();
            this.lblChangeValue = new System.Windows.Forms.Label();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.txtCashGiven = new System.Windows.Forms.TextBox();
            this.lblCashGiven = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbPaymentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPaymentDetails
            // 
            this.gbPaymentDetails.Controls.Add(this.lblChangeValue);
            this.gbPaymentDetails.Controls.Add(this.lblChangeTitle);
            this.gbPaymentDetails.Controls.Add(this.txtCashGiven);
            this.gbPaymentDetails.Controls.Add(this.lblCashGiven);
            this.gbPaymentDetails.Controls.Add(this.cmbPaymentMethod);
            this.gbPaymentDetails.Controls.Add(this.lblMethod);
            this.gbPaymentDetails.Controls.Add(this.lblTotalValue);
            this.gbPaymentDetails.Controls.Add(this.lblTotalTitle);
            this.gbPaymentDetails.Location = new System.Drawing.Point(20, 20);
            this.gbPaymentDetails.Name = "gbPaymentDetails";
            this.gbPaymentDetails.Size = new System.Drawing.Size(390, 240);
            this.gbPaymentDetails.TabIndex = 0;
            this.gbPaymentDetails.TabStop = false;
            this.gbPaymentDetails.Text = "Chi tiết thanh toán";
            // 
            // lblChangeValue
            // 
            this.lblChangeValue.AutoSize = true;
            this.lblChangeValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblChangeValue.ForeColor = System.Drawing.Color.Green;
            this.lblChangeValue.Location = new System.Drawing.Point(130, 180);
            this.lblChangeValue.Name = "lblChangeValue";
            this.lblChangeValue.Size = new System.Drawing.Size(48, 16);
            this.lblChangeValue.TabIndex = 0;
            this.lblChangeValue.Text = "0 VNĐ";
            // 
            // lblChangeTitle
            // 
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.lblChangeTitle.Location = new System.Drawing.Point(20, 180);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(72, 16);
            this.lblChangeTitle.TabIndex = 1;
            this.lblChangeTitle.Text = "Tiền thừa:";
            // 
            // txtCashGiven
            // 
            this.txtCashGiven.Location = new System.Drawing.Point(130, 125);
            this.txtCashGiven.Name = "txtCashGiven";
            this.txtCashGiven.Size = new System.Drawing.Size(230, 20);
            this.txtCashGiven.TabIndex = 2;
            // 
            // lblCashGiven
            // 
            this.lblCashGiven.AutoSize = true;
            this.lblCashGiven.Location = new System.Drawing.Point(20, 130);
            this.lblCashGiven.Name = "lblCashGiven";
            this.lblCashGiven.Size = new System.Drawing.Size(86, 13);
            this.lblCashGiven.TabIndex = 3;
            this.lblCashGiven.Text = "Tiền khách đưa:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản / Quẹt thẻ"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(130, 80);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(230, 21);
            this.cmbPaymentMethod.TabIndex = 4;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(20, 85);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(71, 13);
            this.lblMethod.TabIndex = 5;
            this.lblMethod.Text = "Phương thức:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.Red;
            this.lblTotalValue.Location = new System.Drawing.Point(200, 38);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(128, 19);
            this.lblTotalValue.TabIndex = 6;
            this.lblTotalValue.Text = "35,000,000 VNĐ";
            this.lblTotalValue.Click += new System.EventHandler(this.lblTotalValue_Click);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 40);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(156, 16);
            this.lblTotalTitle.TabIndex = 7;
            this.lblTotalTitle.Text = "Tổng tiền thanh toán:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(50, 280);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 40);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Xác nhận thu tiền";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(230, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmPayment
            // 
            this.ClientSize = new System.Drawing.Size(450, 380);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbPaymentDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán Đơn Hàng";
            this.gbPaymentDetails.ResumeLayout(false);
            this.gbPaymentDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPaymentDetails;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblCashGiven;
        private System.Windows.Forms.TextBox txtCashGiven;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChangeValue;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}