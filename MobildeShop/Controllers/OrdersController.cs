using MobildeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobildeShop.Controllers
{
    public class OrdersController : Controller
    {
        private MobileShopEntities db = new MobileShopEntities();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderManager()
        {
            return View();
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

        [HttpGet]
        public JsonResult SearchOrder(string text, int number, int page, string sortBy, bool isAsc)
        {
            // filtering
            List<Order> list = new List<Order>();
            if (String.IsNullOrEmpty(text))
            {
                list = db.Orders.OrderBy(p => p.id).ToList();
            }
            else
            {
                list = db.Orders.Where(p => p.Customer.Name.Contains(text) || p.Title.Contains(text)
                || p.CreatedDate.ToString().Contains(text) || p.TotalAmount.ToString().Contains(text)).OrderBy(p => p.id).ToList();

            }

            // sorting
            switch (sortBy)
            {

                case "Title":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Title).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Title).ToList();
                    }

                    break;

                case "Name":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Customer.Name).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Customer.Name).ToList();
                    }

                    break;

                case "Price":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.TotalAmount).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.TotalAmount).ToList();
                    }

                    break;

                default:
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.CreatedDate).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.CreatedDate).ToList();
                    }
                    break;

            }


            int count = list.Count;
            list = list.Skip(number * page).Take(number).ToList();
            return Json(new { list, count }, JsonRequestBehavior.AllowGet);
        }
    }
}
