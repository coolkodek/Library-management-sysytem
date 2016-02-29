using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DbUtil;

namespace Library.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool orderbooks(string customer,string objectid)
        {
            return new DbUtility().UpdateDocumentsByObjectIdForMultipleAttributes(objectid, "Persons", customer);
        }

        [HttpGet]
        public string getbooks()
        {
          
            return new DbUtility().GetDocumentsByQuery("books", "{Isavailable:\"Y\"}");
        }
        [HttpGet]
        public string getstates()
        {

            return new DbUtility().GetAllDocuments("State");
        }
        [HttpGet]
        public string getdistricts()
        {

            return new DbUtility().GetAllDocuments("District");
        }
        [HttpGet]
        public string gettalukas()
        {

            return new DbUtility().GetAllDocuments("Taluka");
        }
        [HttpGet]
        public string getcustomer(string objectid)
        {
            return new DbUtility().GetDocumentByObjectIdWithObjectId("Persons", "_id", objectid);

        }
        [HttpGet]
        public string getcustomers()
        {
            return new DbUtility().GetDocumentByIdWithObjectId("Persons", "role", "customer");

        }
        [HttpPost]
        public bool addcustomer(string objectid,string customer)
        {
            return new DbUtility().UpdateDocumentsByObjectIdForMultipleAttributes(objectid, "Persons", customer);
        }
        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
           
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
