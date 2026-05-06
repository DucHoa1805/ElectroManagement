# Setup Guide - ElectroManagement

Hướng dẫn cài đặt và chạy ElectroManagement trên máy của bạn.

## Yêu Cầu Tiên Quyết

1. **Visual Studio 2022** hoặc **Visual Studio Community 2026**
2. **.NET Framework 4.8**
3. **SQL Server 2019** hoặc **SQL Server 2022**
4. **Git**

## Bước 1: Clone Repository

```bash
git clone https://github.com/DucHoa1805/ElectroManagement.git
cd ElectroManagement
```

## Bước 2: Cài Đặt SQL Server Database

### Option A: Sử dụng SQL Server Management Studio (SSMS)

1. Mở SSMS
2. Connect tới server `BOMAYLAHACKER` (hoặc server name của bạn)
3. Chạy script tạo database:

```sql
CREATE DATABASE ElelectroDB;
```

4. Tạo các bảng:

```sql
USE ElelectroDB;

CREATE TABLE Brands (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName NVARCHAR(100) NOT NULL
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(200) NOT NULL,
    CategoryID INT NOT NULL,
    BrandID INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
);

CREATE TABLE ProductVariants (
    VariantID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    SKU NVARCHAR(50),
    Color NVARCHAR(50),
    Storage NVARCHAR(50),
    Price DECIMAL(10, 2),
    Quantity INT DEFAULT 0,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE InventoryTransactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    VariantID INT NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    ChangeQuantity INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(15, 2),
    Status NVARCHAR(50)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    VariantID INT NOT NULL,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    Amount DECIMAL(15, 2),
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    Action NVARCHAR(100),
    TableName NVARCHAR(50),
    RecordID INT,
    Timestamp DATETIME DEFAULT GETDATE()
);
```

### Option B: Sử dụng Connection String Wizard (trong Visual Studio)

1. Mở Visual Studio
2. View > SQL Server Object Explorer
3. Add SQL Server
4. Input server name: `BOMAYLAHACKER`
5. Database sẽ tự tạo khi chạy application (nếu EnableAutoInitialize = true)

## Bước 3: Cấu Hình Connection String

Sửa file `ElectroManagement/Database/DatabaseHelper.cs`:

```csharp
private static string connectionString = @"Server=BOMAYLAHACKER; Database=ElelectroDB; Integrated Security=True;";
```

**Thay đổi:**
- `BOMAYLAHACKER` → Tên server SQL của bạn
- `ElelectroDB` → Tên database (giữ nguyên nếu tạo theo script trên)
- `Integrated Security=True` → Nếu sử dụng Windows Authentication

## Bước 4: Mở Project trong Visual Studio

1. Mở Visual Studio
2. File > Open > Project/Solution
3. Chọn `ElectroManagement.sln`

## Bước 5: Restore NuGet Packages

1. Tools > NuGet Package Manager > Package Manager Console
2. Chạy: `Update-Package`

Hoặc:
1. Solution Explorer > Right-click on Solution
2. Restore NuGet Packages

## Bước 6: Build Project

- Bấm `Ctrl+Shift+B` để build
- Hoặc Build > Build Solution

## Bước 7: Chạy Application

- Bấm `F5` để chạy Debug
- Hoặc `Ctrl+F5` để chạy Release

## Troubleshooting

### Lỗi: "Cannot open database 'ElelectroDB'"

**Giải pháp:**
- Kiểm tra SQL Server đang chạy
- Kiểm tra tên server đúng
- Chạy script tạo database

### Lỗi: "Login failed for user ''"

**Giải pháp:**
- Kiểm tra connection string
- Sửa `Integrated Security=True` hoặc `User ID=sa; Password=xxx`
- Restart SQL Server

### Lỗi: "Provider named pipes provider, error: 40"

**Giải pháp:**
- SQL Server chưa được enable cho remote connections
- Hoặc sử dụng `.\SQLEXPRESS` nếu dùng SQL Server Express

### Lỗi: "The name 'InitializeComponent' does not exist"

**Giải pháp:**
- Đóng Visual Studio
- Xóa `.vs` folder
- Xóa `bin` và `obj` folder
- Mở lại Visual Studio

## Cấu Trúc Folder Sau Setup

```
ElectroManagement/
├── .git/
├── .gitignore
├── README.md
├── CONTRIBUTING.md
├── SETUP.md
├── ElectroManagement/
│   ├── bin/
│   ├── obj/
│   ├── Properties/
│   ├── Controllers/
│   ├── Views/
│   ├── Models/
│   ├── Database/
│   ├── Program.cs
│   └── ElectroManagement.csproj
└── ElectroManagement.sln
```

## Testing Application

1. Chạy app (F5)
2. Click "Quản Lý Sản Phẩm" để test CRUD product
3. Click "Quản Lý Kho" để test inventory
4. Tạo sản phẩm trước, sau đó nhập kho
5. Kiểm tra lịch sử giao dịch

## Tips

- Sử dụng Ctrl+K, Ctrl+D để format code
- Sử dụng Ctrl+. để quick fix errors
- Sử dụng F7 để toggle code/design view
- Sử dụng Debug > Windows > Locals để debug variables

## Liên Hệ

Nếu có vấn đề, tạo Issue trên GitHub hoặc liên hệ tác giả.
