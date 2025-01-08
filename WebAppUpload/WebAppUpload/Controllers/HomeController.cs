using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppUpload.Models;

namespace WebAppUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            BaseProduct baseProduct = new BaseProduct();
            baseProduct.QryProduct(1);

            return View();
        }
        [HttpPost]
        public ActionResult Contact(HttpPostedFileBase FileUpload)
        { 
            string FileName= FileUpload.FileName;
            FileUpload.SaveAs(Server.MapPath("~/Temp/")+ FileName);//

            string Url = "http://localhost:54972/Temp/" + FileName;
            ViewBag.ImageUrl = Url;
            return View();
        }

        public JsonResult GetProduct(int productid)//http://localhost:54972/Home/GetProduct?productid=1
        {
            BaseProduct baseProduct = new BaseProduct();
            baseProduct.QryProduct(productid);
            return Json(baseProduct, JsonRequestBehavior.AllowGet);
        }
    }
}