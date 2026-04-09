using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ElectroManagement.Models;
using ElectroManagement.Database;

namespace ElectroManagement.Controllers
{
    public class ProductController
    {
        // Lấy danh sách sản phẩm
        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Products WHERE IsDeleted = 0";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product()
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        CategoryID = (int)reader["CategoryID"],
                        BrandID = (int)reader["BrandID"],
                        Description = reader["Description"].ToString(),
                        IsDeleted = (bool)reader["IsDeleted"]
                    };

                    list.Add(p);
                }
            }

            return list;
        }

        // Thêm sản phẩm
        public void Add(Product p)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Products(ProductName, CategoryID, BrandID, Description)
                                 VALUES(@name, @cate, @brand, @desc)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", p.ProductName);
                cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                cmd.Parameters.AddWithValue("@brand", p.BrandID);
                cmd.Parameters.AddWithValue("@desc", p.Description ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Sửa sản phẩm
        public void Update(Product p)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Products 
                                 SET ProductName=@name, CategoryID=@cate, BrandID=@brand, Description=@desc
                                 WHERE ProductID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", p.ProductID);
                cmd.Parameters.AddWithValue("@name", p.ProductName);
                cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                cmd.Parameters.AddWithValue("@brand", p.BrandID);
                cmd.Parameters.AddWithValue("@desc", p.Description ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Xóa mềm (soft delete)
        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Products SET IsDeleted = 1 WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}