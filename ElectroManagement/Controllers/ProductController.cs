using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models;

namespace ElectroManagement.Controllers
{
    public class ProductController
    {
        // 1. Lấy danh sách hiển thị lên DataGridView
        public DataTable GetAllView()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                // Dùng LEFT JOIN để lấy tên từ bảng khác nhưng vẫn giữ các cột ID ẩn
                string query = @"
                    SELECT 
                        p.ProductID, p.ProductName, 
                        p.CategoryID, p.BrandID, 
                        c.CategoryName, b.BrandName, 
                        p.Description 
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    LEFT JOIN Brands b ON p.BrandID = b.BrandID
                    WHERE p.IsDeleted = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Hàm Thêm mới
        public void Add(Product p)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Products (ProductName, CategoryID, BrandID, Description) 
                                 VALUES (@name, @cate, @brand, @desc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", p.ProductName);
                cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                cmd.Parameters.AddWithValue("@brand", p.BrandID);
                cmd.Parameters.AddWithValue("@desc", (object)p.Description ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 3. Hàm Cập nhật (Sửa) - Đã sửa lỗi Invalid Column Name
        public void Update(Product p)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Products 
                                 SET ProductName=@name, 
                                     CategoryID=@cate, 
                                     BrandID=@brand, 
                                     Description=@desc 
                                 WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", p.ProductID);
                cmd.Parameters.AddWithValue("@name", p.ProductName);
                cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                cmd.Parameters.AddWithValue("@brand", p.BrandID);
                cmd.Parameters.AddWithValue("@desc", (object)p.Description ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 4. Hàm Xóa mềm
        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Products SET IsDeleted = 1 WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}