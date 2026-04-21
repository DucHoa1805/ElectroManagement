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

        private static string connectionString = @"Server=.\SQLEXPRESS; Database=ElelectroDB; Integrated Security=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}