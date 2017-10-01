using MobildeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobildeShop.Controllers
{
    public class CustomersController : Controller
    {
        private MobileShopEntities db = new MobileShopEntities();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCustomerByPhone(string phone)
        {
            if (String.IsNullOrEmpty(phone))
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            Customer c = db.Customers.FirstOrDefault(cus => cus.Phone == phone);
            if (c == null)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { c }, JsonRequestBehavior.AllowGet);
        }

        

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
