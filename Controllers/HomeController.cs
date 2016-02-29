using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DbUtil;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public string addcustomer(string customer)
        {
            return new DbUtility().SaveDocumentAndReturnObjectId(customer, "Persons");
        }
        [HttpPost]
        public string validate(string user)
        {

            return new DbUtility().GetDocumentByMultipleAttributes("Persons", user);
            
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
    }
}
