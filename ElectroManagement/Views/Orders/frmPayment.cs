using System;
using System.Windows.Forms;
using ElectroManagement.Controllers.Orders;

namespace ElectroManagement.Views.Orders
{
    public partial class frmPayment : Form
    {
        private PaymentController _paymentController;
        private decimal _totalAmount = 0;

        // Cửa số 1: Phòng hờ có file nào gọi cũ không bị báo lỗi
        public frmPayment()
        {
            InitializeComponent();
            SetupForm();
        }

        // Cửa số 2: Mở từ frmOrder và nhận tổng tiền
        public frmPayment(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            SetupForm();
        }

        // Hàm gộp các cài đặt cho gọn code
        private void SetupForm()
        {
            lblTotalValue.Text = $"{_totalAmount:N0} VNĐ";
            _paymentController = new PaymentController();

            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;

            txtCashGiven.TextChanged += TxtCashGiven_TextChanged;
            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        // Hàm dỗ dành màn hình Design để không báo lỗi click chuột
        private void lblTotalValue_Click(object sender, EventArgs e)
        {
            // Để trống
        }

        // Tự động tính tiền thừa
        private void TxtCashGiven_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCashGiven.Text, out decimal cashGiven))
            {
                decimal change = cashGiven - _totalAmount;
                lblChangeValue.Text = change > 0 ? $"{change:N0} VNĐ" : "0 VNĐ";
            }
            else
            {
                lblChangeValue.Text = "0 VNĐ";
            }
        }

        // Bấm Xác nhận
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string method = cmbPaymentMethod.SelectedItem.ToString();
            _paymentController.ProcessPayment(method, _totalAmount);
            this.Close();
        }

        // Bấm Hủy bỏ
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}