using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ssds = "";
            DataTable dt = fetchData();
            ViewBag.pData = dt;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string CmdType,string submit,string txtA,string txtB)
        {
            if (submit == "Sum")
            {
                int a = Convert.ToInt16(txtA);
                int b = Convert.ToInt16(txtB);
                ViewBag.Output = (a + b).ToString();
            }
            //ViewBag.Output
            if (submit == "Query Data")
            {
                DataTable dt = fetchData();
                ViewBag.pData = dt;
            }
           
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private DataTable fetchData()
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