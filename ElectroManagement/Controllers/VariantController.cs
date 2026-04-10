using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models; // Sử dụng Model của bạn

namespace ElectroManagement.Controllers
{
    public class VariantController
    {
        // 1. Lấy danh sách kiểu dáng theo ID sản phẩm
        public DataTable GetByProductId(int productId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT VariantID, ProductID, SKU, Color, Storage, Price, Quantity FROM ProductVariants WHERE ProductID = @pid";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@pid", productId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Thêm mới dùng Model
        public void Add(ProductVariant v)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO ProductVariants (ProductID, SKU, Color, Storage, Price, Quantity) 
                                 VALUES (@pid, @sku, @color, @storage, @price, @qty)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pid", v.ProductID);
                cmd.Parameters.AddWithValue("@sku", (object)v.SKU ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@color", (object)v.Color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@storage", (object)v.Storage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", v.Price);
                cmd.Parameters.AddWithValue("@qty", v.Quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 3. Cập nhật dùng Model
        public void Update(ProductVariant v)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE ProductVariants 
                                 SET SKU=@sku, Color=@color, Storage=@storage, Price=@price, Quantity=@qty 
                                 WHERE VariantID=@vid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vid", v.VariantID);
                cmd.Parameters.AddWithValue("@sku", (object)v.SKU ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@color", (object)v.Color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@storage", (object)v.Storage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", v.Price);
                cmd.Parameters.AddWithValue("@qty", v.Quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 4. Xóa kiểu dáng
        public void Delete(int variantId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM ProductVariants WHERE VariantID = @vid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vid", variantId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}