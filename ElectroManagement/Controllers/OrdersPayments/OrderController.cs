using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ElectroManagement.Database;
using ElectroManagement.Helpers;
using ElectroManagement.Controllers.Report.AuditLog;
using ElectroManagement.Models.OrderEntities;
using ElectroManagement.Models.ProductEntities;

namespace ElectroManagement.Controllers.Orders
{
    public class OrderController
    {
        
        /// Lấy danh sách tất cả ProductVariants từ database
       
        public List<ProductVariant> GetAllProductVariants()
        {
            List<ProductVariant> variants = new List<ProductVariant>();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT VariantID, ProductID, SKU, Color, Storage, Price, Quantity 
                                    FROM ProductVariants 
                                    ORDER BY ProductID, Color, Storage";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        variants.Add(new ProductVariant
                        {
                            VariantID = (int)reader["VariantID"],
                            ProductID = (int)reader["ProductID"],
                            SKU = reader["SKU"].ToString(),
                            Color = reader["Color"].ToString(),
                            Storage = reader["Storage"].ToString(),
                            Price = (decimal)reader["Price"],
                            Quantity = (int)reader["Quantity"]
                        });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách sản phẩm: {ex.Message}", "Lỗi");
            }

            return variants;
        }

      
        /// Lấy thông tin chi tiết của một ProductVariant
       
        public ProductVariant GetProductVariantById(int variantId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT VariantID, ProductID, SKU, Color, Storage, Price, Quantity 
                                    FROM ProductVariants 
                                    WHERE VariantID = @variantId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@variantId", variantId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new ProductVariant
                        {
                            VariantID = (int)reader["VariantID"],
                            ProductID = (int)reader["ProductID"],
                            SKU = reader["SKU"].ToString(),
                            Color = reader["Color"].ToString(),
                            Storage = reader["Storage"].ToString(),
                            Price = (decimal)reader["Price"],
                            Quantity = (int)reader["Quantity"]
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin sản phẩm: {ex.Message}", "Lỗi");
            }

            return null;
        }

    
        /// Thêm sản phẩm vào giỏ hàng (tạo OrderDetail mới)
     
        public OrderDetail AddOrderDetail(int variantId, int quantity, BindingList<OrderDetail> currentCart)
        {
            try
            {
                // Kiểm tra input
                if (quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo");
                    return null;
                }

                // Lấy thông tin sản phẩm từ database
                ProductVariant product = GetProductVariantById(variantId);

                if (product == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại!", "Cảnh báo");
                    return null;
                }

                // Kiểm tra tồn kho
                if (product.Quantity < quantity)
                {
                    MessageBox.Show($"Không đủ hàng! Còn lại: {product.Quantity}", "Cảnh báo");
                    return null;
                }

                // Tạo OrderDetail mới
                OrderDetail newItem = new OrderDetail
                {
                    VariantID = variantId,
                    ProductName = $"{product.Color} - {product.Storage} (SKU: {product.SKU})",
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    SubTotal = product.Price * quantity
                };

                // Kiểm tra xem sản phẩm đã có trong giỏ chưa
                foreach (OrderDetail item in currentCart)
                {
                    if (item.VariantID == variantId)
                    {
                        // Kiểm tra tổng số lượng có vượt quá số lượng trong kho không
                        if (item.Quantity + quantity > product.Quantity)
                        {
                            MessageBox.Show($"Không đủ hàng! \nCòn lại: {product.Quantity}\nĐã có trong giỏ: {item.Quantity}\nBạn đang thêm: {quantity}", "Cảnh báo");
                            return null;
                        }

                        // Nếu có rồi, cộng thêm số lượng
                        item.Quantity += quantity;
                        item.SubTotal = item.Quantity * item.UnitPrice;
                        // Kích phát sự kiện cập nhật hiển thị (cần dùng IndexOf, nhưng vì đang trong foreach sẽ có vấn đề return luôn là đc)
                        return item;
                    }
                }

                return newItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi");
                return null;
            }
        }

    
        /// Cập nhật số lượng OrderDetail trong giỏ
      
        public bool UpdateOrderDetail(int cartIndex, int newQuantity, BindingList<OrderDetail> cart)
        {
            try
            {
                if (cartIndex < 0 || cartIndex >= cart.Count)
                {
                    MessageBox.Show("Chỉ mục không hợp lệ!", "Cảnh báo");
                    return false;
                }

                if (newQuantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo");
                    return false;
                }

                OrderDetail item = cart[cartIndex];

                // Lấy thông tin sản phẩm để check tồn kho
                ProductVariant product = GetProductVariantById(item.VariantID);

                if (product == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại!", "Cảnh báo");
                    return false;
                }

                if (product.Quantity < newQuantity)
                {
                    MessageBox.Show($"Không đủ hàng! Còn lại: {product.Quantity}", "Cảnh báo");
                    return false;
                }

                // Cập nhật
                item.Quantity = newQuantity;
                item.SubTotal = item.Quantity * item.UnitPrice;
                cart.ResetItem(cartIndex);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi");
                return false;
            }
        }

   
        /// Xóa sản phẩm khỏi giỏ hàng

        public bool RemoveOrderDetail(int cartIndex, BindingList<OrderDetail> cart)
        {
            try
            {
                if (cartIndex < 0 || cartIndex >= cart.Count)
                {
                    MessageBox.Show("Chỉ mục không hợp lệ!", "Cảnh báo");
                    return false;
                }

                cart.RemoveAt(cartIndex);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi");
                return false;
            }
        }
        /// Xóa tất cả sản phẩm trong giỏ hàng
        public void ClearCart(BindingList<OrderDetail> cart)
        {
            if (cart.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cart.Clear();
                    MessageBox.Show("Giỏ hàng đã được làm trống!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Giỏ hàng đã trống!", "Thông báo");
            }
        }

        /// <summary>
        /// Tính tổng tiền của giỏ hàng
        /// </summary>
        public decimal CalculateCartTotal(BindingList<OrderDetail> cart)
        {
            decimal total = 0;

            foreach (OrderDetail item in cart)
            {
                total += item.SubTotal;
            }

            return total;
        }

        /// <summary>
        /// Tạo một đơn hàng mới trong database với trạng thái 'Pending'
        /// </summary>
        /// <param name="order">Thông tin đơn hàng</param>
        /// <returns>ID của đơn hàng vừa tạo</returns>
        public int CreateOrder(Order order)
        {
            int orderId = 0;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // ĐÃ FIX: Thêm cột PaymentStatus vào lệnh INSERT
                    string orderQuery = @"
                        INSERT INTO Orders (CustomerName, Phone, TotalAmount, Status, OrderDate, PaymentStatus)
                        OUTPUT INSERTED.OrderID
                        VALUES (@CustomerName, @Phone, @TotalAmount, @Status, @OrderDate, @PaymentStatus)";

                    SqlCommand orderCmd = new SqlCommand(orderQuery, conn, transaction);
                    orderCmd.Parameters.AddWithValue("@CustomerName", (object)order.CustomerName ?? DBNull.Value);
                    orderCmd.Parameters.AddWithValue("@Phone", (object)order.Phone ?? DBNull.Value);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                    orderCmd.Parameters.AddWithValue("@Status", "Pending"); // Trạng thái đơn ban đầu
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                    // Gán mặc định trạng thái thanh toán là "Chưa thanh toán" khi vừa tạo đơn
                    orderCmd.Parameters.AddWithValue("@PaymentStatus", "Chưa thanh toán");

                    orderId = (int)orderCmd.ExecuteScalar();

                    // 2. Insert vào bảng OrderDetails
                    foreach (var detail in order.OrderDetails)
                    {
                        string detailQuery = @"
                            INSERT INTO OrderDetails (OrderID, VariantID, Quantity, UnitPrice)
                            VALUES (@OrderID, @VariantID, @Quantity, @UnitPrice)";

                        SqlCommand detailCmd = new SqlCommand(detailQuery, conn, transaction);
                        detailCmd.Parameters.AddWithValue("@OrderID", orderId);
                        detailCmd.Parameters.AddWithValue("@VariantID", detail.VariantID);
                        detailCmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                        detailCmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);

                        detailCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi");
                    return 0; // Trả về 0 nếu có lỗi
                }
            }

            // Ghi audit log cho hành động tạo đơn hàng
            try
            {
                var audit = new AuditController();
                int? userId = null;
                if (Session.IsLoggedIn && Session.CurrentUser != null)
                    userId = Session.CurrentUser.UserID;

                audit.AddLog(userId, $"Create order OrderID={orderId} Total={order.TotalAmount}", "Orders");
            }
            catch { }

            return orderId;
        }

        /// Lấy danh sách sản phẩm dạng DataTable (để bind vào ComboBox)
        public DataTable GetProductsForComboBox()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT VariantID, 
                                            (SELECT ProductName FROM Products WHERE ProductID = pv.ProductID) + ' - ' + 
                                            pv.Color + ' - ' + pv.Storage + ' (Giá: ' + CAST(pv.Price AS NVARCHAR) + ')' AS DisplayName,
                                            pv.Price, pv.Quantity
                                    FROM ProductVariants pv
                                    WHERE pv.Quantity > 0
                                    ORDER BY ProductID, Color, Storage";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi");
                return new DataTable();
            }
        }

        /// <summary>
        /// Validate OrderDetail trước khi checkout
        /// </summary>
        public bool ValidateOrder(BindingList<OrderDetail> cart, string customerName, string phone)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm.", "Cảnh báo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo");
                return false;
            }

            return true;
        }
    }
}