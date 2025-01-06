using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApplication.Model;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ssds = "";
            TestModel ss = new TestModel();
            DataTable dt = ss.fetchData();
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
            //if (submit == "Query Data")
            //{
            //    TestModel ss = new TestModel();
            //    DataTable dt = ss.fetchData();
            //    ViewBag.pData = dt;
            //}
            string ssds = "";
            TestModel ss = new TestModel();
            DataTable dt = ss.fetchData();
            ViewBag.pData = dt;


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
        
    }
}