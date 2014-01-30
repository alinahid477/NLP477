using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLP477.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.JSONData = this.JSONTest();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        private string JSONTest()
        { 
            string json = "";
            using(StreamReader sr = new StreamReader("C:\\Ali\\RR\\NETTools\\NLP477\\AccommodationJson.TXT"))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            return json;
        }

    }
}
