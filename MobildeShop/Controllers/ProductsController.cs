using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobildeShop.Models;

namespace MobildeShop.Controllers
{
    public class ProductsController : Controller
    {
        private MobileShopEntities db = new MobileShopEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public JsonResult SearchProducts(string text, int number, int page)
        {
            List<Product> list = new List<Product>();
            if (String.IsNullOrEmpty(text))
            {
                list = db.Products.OrderBy(p => p.id).ToList();
            }
            else
            {
                list = db.Products.Where(p => p.Code.Contains(text) || p.Title.Contains(text) 
                || p.Description.Contains(text) || p.Price.ToString().Contains(text)).OrderBy(p => p.id).ToList();

            }
            int count = list.Count;
            list = list.Skip(number * page).Take(number).ToList();
            return Json(new { list, count }, JsonRequestBehavior.AllowGet);
        }

    }
}
