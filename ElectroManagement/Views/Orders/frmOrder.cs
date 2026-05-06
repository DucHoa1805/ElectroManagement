using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ElectroManagement.Models.OrderEntities;
using ElectroManagement.Controllers.Orders;

namespace ElectroManagement.Views.Orders
{
    public partial class frmOrder : Form
    {
        private BindingList<OrderDetail> _gioHang = new BindingList<OrderDetail>();
        private OrderController _orderController = new OrderController();

        public frmOrder()
        {
            InitializeComponent();

            // 1. Tùy chỉnh DataGridView: Ẩn cột thừa, cấu hình cột hiển thị
            FormatDataGridView();

            // 2. Gán DataSource sau khi đã cấu hình cột
            dgvOrderDetails.DataSource = _gioHang;
            LoadProductsToCombo();
        }

        /// <summary>
        /// Định cấu hình DataGridView để chỉ hiển thị các cột cần thiết
        /// </summary>
        private void FormatDataGridView()
        {
            // Tắt tự động tạo cột
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.Columns.Clear();

            // Cột Tên sản phẩm
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên Sản Phẩm",
                Width = 220 // Tăng chiều rộng để hiển thị đủ tên máy
            });

            // Cột Số lượng
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số Lượng",
                Width = 80
            });

            // FIX: Đổi "Price" thành "UnitPrice" cho khớp với OrderDetail class
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn Giá",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            // ADD: Thêm cột Thành Tiền (SubTotal)
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Thành Tiền",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 120
            });

            // Cột Tồn kho
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Tồn Kho",
                Width = 80
            });
        }

        /// <summary>
        /// Load danh sách sản phẩm vào ComboBox từ database
        /// </summary>
        private void LoadProductsToCombo()
        {
            try
            {
                DataTable dtProducts = _orderController.GetProductsForComboBox();

                if (dtProducts.Rows.Count > 0)
                {
                    cmbProduct.DataSource = dtProducts;
                    cmbProduct.DisplayMember = "DisplayName";
                    cmbProduct.ValueMember = "VariantID";
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào trong kho!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi");
            }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            // Auto update
        }

        /// <summary>
        /// Nút "Thêm" - Thêm sản phẩm vào giỏ hàng
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Cảnh báo");
                    return;
                }

                int variantId = (int)cmbProduct.SelectedValue;
                int quantity = (int)nudQuantity.Value;

                // Lấy tồn kho hiện tại từ DataTable đã load vào ComboBox
                int stock = 0;
                var dt = cmbProduct.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if ((int)r["VariantID"] == variantId)
                        {
                            stock = r.Table.Columns.Contains("Quantity") ? Convert.ToInt32(r["Quantity"]) : 0;
                            break;
                        }
                    }
                }

                // KIỂM TRA SỐ LƯỢNG BẰNG ID SẢN PHẨM (VariantID)
                int currentQtyInCart = 0;
                foreach (var item in _gioHang)
                {
                    if (item.VariantID == variantId)
                    {
                        currentQtyInCart = item.Quantity;
                        break;
                    }
                }

                // Nếu tổng số lượng (đang có trong giỏ + chuẩn bị thêm) vượt quá tồn kho thì chặn lại
                if (currentQtyInCart + quantity > stock)
                {
                    MessageBox.Show($"Không đủ số lượng trong kho!\nTồn kho: {stock}\nĐã có trong giỏ: {currentQtyInCart}\nBạn đang thêm: {quantity}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực thi, không cho thêm
                }

                // Gọi OrderController để thêm sản phẩm
                OrderDetail newItem = _orderController.AddOrderDetail(variantId, quantity, _gioHang);

                if (newItem != null)
                {
                    newItem.Stock = stock;

                    // FIX TÊN SẢN PHẨM: Lấy tên đẹp từ ComboBox và cắt bỏ đoạn "(Giá: ...)"
                    string rawName = cmbProduct.Text;
                    int indexGia = rawName.IndexOf(" (Giá:");

                    if (indexGia > 0)
                    {
                        // Cắt chuỗi để lấy phần "Galaxy S22 - Black - 128GB"
                        newItem.ProductName = rawName.Substring(0, indexGia);
                    }
                    else
                    {
                        newItem.ProductName = rawName;
                    }

                    if (!_gioHang.Contains(newItem))
                        _gioHang.Add(newItem);
                }
                ToolTip toastTooltip = new ToolTip();
                toastTooltip.ToolTipIcon = ToolTipIcon.Info;
                toastTooltip.ToolTipTitle = "Thành công";
                toastTooltip.UseFading = true;
                toastTooltip.UseAnimation = true;

                // Hiện thông báo ở vị trí phía trên nút "Thêm", tự động tắt sau 1.5 giây (1500 ms)
                toastTooltip.Show("Đã cập nhật giỏ hàng!", btnAdd, 0, -50, 1500);
                // -----------------------------------------------------------
                // Làm mới DataGridView để cập nhật giao diện
                dgvOrderDetails.Refresh();

                // Reset số lượng về 1 sau khi thêm thành công
                nudQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        /// <summary>
        /// Nút "Xóa" - Xóa sản phẩm khỏi giỏ hàng
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Cảnh báo");
                    return;
                }

                int rowIndex = dgvOrderDetails.CurrentRow.Index;
                _orderController.RemoveOrderDetail(rowIndex, _gioHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        /// <summary>
        /// Nút "Sửa" - Cập nhật số lượng sản phẩm trong giỏ
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!", "Cảnh báo");
                    return;
                }

                int rowIndex = dgvOrderDetails.CurrentRow.Index;
                int newQuantity = (int)nudQuantity.Value;

                _orderController.UpdateOrderDetail(rowIndex, newQuantity, _gioHang);

                // Reset
                nudQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        /// <summary>
        /// Nút "Reset" - Xóa toàn bộ giỏ hàng
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            _orderController.ClearCart(_gioHang);
        }

        /// <summary>
        /// Nút "Thanh toán" - Kiểm tra và gửi đơn hàng
        /// </summary>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (!_orderController.ValidateOrder(_gioHang, txtCustomerName.Text, txtPhone.Text))
                {
                    return;
                }

                // Tính tổng tiền
                decimal tongTien = _orderController.CalculateCartTotal(_gioHang);

                if (tongTien == 0)
                {
                    MessageBox.Show("Giỏ hàng trống trơn!", "Cảnh báo");
                    return;
                }

                // Tạo đối tượng Order
                Order pendingOrder = new Order
                {
                    CustomerName = txtCustomerName.Text,
                    Phone = txtPhone.Text,
                    TotalAmount = tongTien,
                    CreatedAt = DateTime.Now,
                    Status = "Pending"
                };

                // Đưa danh sách OrderDetail vào Order
                foreach (var item in _gioHang)
                {
                    pendingOrder.OrderDetails.Add(item);
                }

                // Lưu đơn hàng vào database
                int orderId = _orderController.CreateOrder(pendingOrder);

                if (orderId > 0)
                {
                    MessageBox.Show($"Đã tạo đơn hàng! Mã ĐH: {orderId}. Tiến hành thanh toán.", "Thông báo");

                    // Truyền thêm orderId vào frmPayment
                    frmPayment formThanhToan = new frmPayment(orderId, tongTien);

                    if (formThanhToan.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi thanh toán thành công, reset giỏ hàng
                        _gioHang.Clear();
                        txtCustomerName.Text = "";
                        txtPhone.Text = "";
                        nudQuantity.Value = 1;
                    }
                    else
                    {
                        // Có thể thêm xử lý khi hủy thanh toán ở đây
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo đơn hàng.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

       
    }
}