using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ElectroManagement.Database
{
    public class DatabaseHelper
    {

        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ElelectroDB;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}