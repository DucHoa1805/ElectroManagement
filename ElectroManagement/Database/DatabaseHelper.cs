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

        private static string connectionString = @"Data Source=DESKTOP-PRJK00R\SQLEXPRESS01;Initial Catalog=ElelectroDB12;Integrated Security=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}