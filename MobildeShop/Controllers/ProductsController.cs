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
        public JsonResult SearchProducts(string text, int number, int page, string sortBy, bool isAsc)
        {
            // filtering
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

            // sorting
            switch (sortBy)
            {
                //case "Code":
                //    if(isAsc)
                //    {
                //        list = list.OrderBy(p => p.Code).ToList();
                //    }
                //    else
                //    {
                //        list = list.OrderByDescending(p => p.Code).ToList();
                //    }

                //    break;

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

                case "Description":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Description).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Description).ToList();
                    }

                    break;

                case "Price":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Price).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Price).ToList();
                    }

                    break;

                default:
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Code).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Code).ToList();
                    }
                    break;

            }

        
            int count = list.Count;
            list = list.Skip(number * page).Take(number).ToList();
            return Json(new { list, count }, JsonRequestBehavior.AllowGet);
        }

    }
}
