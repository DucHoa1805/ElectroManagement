# 📋 QUYTRÌNH NGHIỆP VỤ - ĐƠN HÀNG & THANH TOÁN & XUẤT KHO

## 🔄 Sơ Đồ Quytrình Hoàn Chỉnh

```
┌─────────────────────────────────────────────────────────────────┐
│ 1️⃣  TẠO ĐƠN HÀNG                                               │
│ - Chọn sản phẩm, nhập số lượng                                  │
│ - Nhập tên khách hàng, số điện thoại                            │
│ - OrderController.CreateOrder() tạo đơn với Status = "Pending"  │
└────────────────────┬────────────────────────────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────────────────────────────┐
│ 2️⃣  THANH TOÁN                                                 │
│ - Mở form frmPayment với OrderId                               │
│ - PaymentController.ProcessPayment()                            │
│   + Ghi nhận Payment record                                      │
│   + Cập nhật Order.Status = "Paid"                             │
│   + 🔄 TỰ ĐỘNG gọi xuất kho                                     │
└────────────────────┬────────────────────────────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────────────────────────────┐
│ 3️⃣  XUẤT KHO (Tự động sau thanh toán)                         │
│ - InventoryController.ExportStockForOrder()                     │
│ - Duyệt qua OrderDetails và giảm tồn kho                       │
│ - Ghi nhận InventoryTransaction (Type = "Export")              │
│ - Cập nhật Order.Status = "Completed"                          │
└─────────────────────────────────────────────────────────────────┘
```

---

## 📝 Chi Tiết Quytrình

### **Bước 1: Tạo Đơn Hàng (frmOrder.cs)**

```csharp
// Người dùng nhấn nút "Thanh toán"
private void btnCheckout_Click(object sender, EventArgs e)
{
    // 1. Nhập thông tin khách hàng
    string customerName = PromptCustomerName();
    string phone = PromptCustomerPhone();

    // 2. Tạo Order với Status = "Pending"
    Order order = new Order
    {
        CustomerName = customerName,
        Phone = phone,
        TotalAmount = tongTien,
        Status = "Pending",  // ← Ban đầu là Pending
        OrderDetails = gioHang
    };

    int orderId = _orderController.CreateOrder(order);

    // 3. Mở form thanh toán với OrderId
    frmPayment formThanhToan = new frmPayment(tongTien, orderId);
    formThanhToan.ShowDialog();
}
```

### **Bước 2: Thanh Toán (frmPayment.cs)**

```csharp
// Người dùng nhấn nút "Xác nhận"
private void BtnConfirm_Click(object sender, EventArgs e)
{
    // Gọi PaymentController với OrderId
    _paymentController.ProcessPayment(_orderId, paymentMethod, _totalAmount);
}
```

### **Bước 3: Xử Lý Thanh Toán & Xuất Kho (PaymentController.cs)**

```csharp
public bool ProcessPayment(int orderId, string paymentMethod, decimal totalAmount)
{
    // 1. Ghi nhận Payments record
    INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid, Status) 
    VALUES (orderId, paymentMethod, totalAmount, "Success")

    // 2. Cập nhật Order Status = "Paid"
    UPDATE Orders SET Status = "Paid" WHERE OrderID = orderId

    // 3. 🔄 TỰ ĐỘNG XUẤT KHO
    ExportInventoryForOrder(orderId)
    {
        // Lấy OrderDetails
        SELECT VariantID, Quantity FROM OrderDetails WHERE OrderID = orderId

        // Mỗi OrderDetail → gọi InventoryController.ExportStockForOrder()
        foreach (orderDetail in orderDetails)
        {
            _inventoryController.ExportStockForOrder(
                variantId: orderDetail.VariantID,
                quantity: orderDetail.Quantity
            );
        }

        // 4. Cập nhật Order Status = "Completed"
        UPDATE Orders SET Status = "Completed" WHERE OrderID = orderId
    }
}
```

### **Bước 4: Xuất Kho (InventoryController.cs)**

```csharp
public void ExportStockForOrder(int variantId, int quantity)
{
    // 1. Kiểm tra đủ hàng
    SELECT Quantity FROM ProductVariants WHERE VariantID = variantId

    // 2. Nếu không đủ → throw Exception
    if (currentQuantity < quantity) 
        throw new Exception("Không đủ hàng!");

    // 3. Ghi nhận InventoryTransaction
    INSERT INTO InventoryTransactions 
    (VariantID, Type, ChangeQuantity, CreatedAt) 
    VALUES (variantId, "Export", quantity, NOW())

    // 4. Giảm tồn kho
    UPDATE ProductVariants 
    SET Quantity = Quantity - quantity 
    WHERE VariantID = variantId
}
```

---

## 🗄️ Trạng Thái Đơn Hàng

| Trạng Thái | Ý Nghĩa | Khi Nào Đạt Tới |
|-----------|---------|----------------|
| **Pending** | Đơn hàng mới, chưa thanh toán | Khi tạo đơn |
| **Paid** | Đã thanh toán, đang chuẩn bị xuất | Khi thanh toán thành công |
| **Completed** | Xuất kho thành công, đơn hoàn tất | Khi xuất kho xong |
| **Cancelled** | Đơn hủy | Chỉ khi Status = Pending |

---

## 📊 Thay Đổi Cơ Sở Dữ Liệu

### **Bảng Orders** - Thêm/Cập nhật columns
```sql
ALTER TABLE Orders ADD Status NVARCHAR(20) DEFAULT 'Pending';
```

### **Bảng Payments** - Thêm Status column
```sql
ALTER TABLE Payments ADD Status NVARCHAR(20) DEFAULT 'Pending';
-- Ví dụ: 'Success', 'Failed', 'Pending'
```

### **Bảng OrderDetails** - Thêm VariantID
```sql
ALTER TABLE OrderDetails ADD VariantID INT;
-- Để tracking sản phẩm và xuất kho
```

---

## 🎯 Lợi Ích Của Quytrình Này

✅ **Tính toàn vẹn dữ liệu**: Không bao giờ xuất kho nếu chưa thanh toán  
✅ **Tự động hóa**: Xuất kho tự động sau thanh toán, không cần nhân viên can thiệp  
✅ **Tracking rõ ràng**: Theo dõi trạng thái từ Pending → Paid → Completed  
✅ **Kiểm soát tồn kho**: Kiểm tra hàng trước xuất kho, tránh bán hàng không có  
✅ **Lịch sử audit**: Ghi nhận đầy đủ trong bảng InventoryTransactions & Payments  

---

## 🔧 Cách Sử Dụng

### **Nhân Viên Bán Hàng**

1. Nhấp menu **"Đơn Hàng"** 
2. Chọn sản phẩm → Nhập số lượng → Nút "Thêm"
3. Nhấp nút "Thanh toán"
4. Nhập tên khách hàng, số điện thoại
5. Chọn phương thức thanh toán
6. Nhấp "Xác nhận" → **Tự động xuất kho** ✅

### **Quản Lý Kho**

- Kiểm tra **"Lịch sử Xuất/Nhập"** để xem giao dịch
- Tồn kho được **tự động cập nhật** sau mỗi thanh toán
- Không cần nhập kho xong rồi xuất kho thủ công

---

## 🚨 Xử Lý Lỗi

| Tình Huống | Xử Lý |
|-----------|-------|
| Khách không thanh toán | Đơn vẫn ở "Pending", không xuất kho |
| Không đủ hàng khi xuất | Hiển thị lỗi, đơn không complete |
| Thanh toán thất bại | Payment.Status = "Failed", Order vẫn "Pending" |

---

## 📁 File Thay Đổi

- ✅ `Models/OrderEntities/Order.cs` - Thêm OrderDetails
- ✅ `Models/OrderEntities/Payment.cs` - Thêm Status
- ✅ `Models/OrderEntities/OrderDetail.cs` - Thêm VariantID
- ✅ `Controllers/OrdersPayments/OrderController.cs` - Toàn bộ logic
- ✅ `Controllers/OrdersPayments/PaymentController.cs` - Gọi xuất kho
- ✅ `Controllers/Inventory/InventoryController.cs` - Thêm ExportStockForOrder()
- ✅ `Views/Orders/frmOrder.cs` - Integrate OrderController
- ✅ `Views/Orders/frmPayment.cs` - Nhận OrderId, gọi ProcessPayment
- ✅ `Views/Main/frmMain.cs` - Implement tsmOrder_Click()

---

## 📞 Hỗ Trợ

Nếu có vấn đề, hãy kiểm tra:
1. **Database columns** có đúng chưa?
2. **OrderDetails** có VariantID không?
3. **Payments** có Status column không?
4. **InventoryTransactions** có ghi nhận type = "Export" không?

Chúc bạn sử dụng hiệu quả! 🚀
