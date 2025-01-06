using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Model
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataTable fetchData()
        {
            DataTable dataTable = new DataTable();

            // Define the connection string
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            // Create a SQL connection object
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "dbo.spOst_LstMember";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            connection.Close();
            return dataTable;
        }

    }
}