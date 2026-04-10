using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;
using ElectroManagement.Models; // Quan trọng: Phải using thư mục Models

namespace ElectroManagement.Controllers
{
    public class BrandController
    {
        // Vẫn dùng DataTable cho GetAll để đổ lên DataGridView nhanh nhất
        public DataTable GetAll()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT BrandID, BrandName FROM Brands";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Dùng Model cho Thêm mới
        public void Add(Brand b) // Truyền vào object Brand
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Brands (BrandName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", b.BrandName); // Lấy từ Model
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Dùng Model cho Cập nhật
        public void Update(Brand b) // Truyền vào object Brand
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Brands SET BrandName = @name WHERE BrandID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", b.BrandID);     // Lấy từ Model
                cmd.Parameters.AddWithValue("@name", b.BrandName); // Lấy từ Model
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Brands WHERE BrandID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}