using System;
using System.Data;
using System.Data.SqlClient;
using ElectroManagement.Database;

namespace ElectroManagement.Controllers.Inventory
{
    public class InventoryController
    {
        public DataTable GetAllHistory()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT TransactionID, VariantID, ChangeQuantity, Type, CreatedAt FROM InventoryTransactions ORDER BY CreatedAt DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void ImportStock(Object trans)
        {
            dynamic transaction = trans;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string insertQuery = @"INSERT INTO InventoryTransactions 
                                       (VariantID, Type, ChangeQuantity, CreatedAt) 
                                       VALUES (@variantId, @type, @quantity, @date)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);
                insertCmd.Parameters.AddWithValue("@type", "Import");
                insertCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                insertCmd.ExecuteNonQuery();

                string updateQuery = @"UPDATE ProductVariants 
                                       SET Quantity = Quantity + @quantity 
                                       WHERE VariantID = @variantId";

                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                updateCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);

                updateCmd.ExecuteNonQuery();
            }
        }

        public void ExportStock(Object trans)
        {
            dynamic transaction = trans;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string insertQuery = @"INSERT INTO InventoryTransactions 
                                       (VariantID, Type, ChangeQuantity, CreatedAt) 
                                       VALUES (@variantId, @type, @quantity, @date)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);
                insertCmd.Parameters.AddWithValue("@type", "Export");
                insertCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                insertCmd.ExecuteNonQuery();

                string updateQuery = @"UPDATE ProductVariants 
                                       SET Quantity = Quantity - @quantity 
                                       WHERE VariantID = @variantId";

                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@quantity", transaction.ChangeQuantity);
                updateCmd.Parameters.AddWithValue("@variantId", transaction.VariantID);

                updateCmd.ExecuteNonQuery();
            }
        }
    }
}
