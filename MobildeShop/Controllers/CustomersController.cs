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
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
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
            //c.DOB = DateTime.Parse(c.DOB?.ToString("dd/MM/yyyy"));
            return Json(new { c }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return Json(customer.id, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SearchCustomers(string text, int number, int page, string sortBy, bool isAsc)
        {
            // filtering
            List<Customer> list = new List<Customer>();
            if (String.IsNullOrEmpty(text))
            {
                list = db.Customers.OrderBy(p => p.id).ToList();
            }
            else
            {
                list = db.Customers.Where(p => p.Name.Contains(text) || p.Phone.Contains(text)
                || p.Email.Contains(text) || p.Address.ToString().Contains(text) || p.IDNumber.ToString().Contains(text)).OrderBy(p => p.id).ToList();

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

                case "Name":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Name).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Name).ToList();
                    }

                    break;

                case "Phone":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Phone).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Phone).ToList();
                    }

                    break;

                case "Email":
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Email).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Email).ToList();
                    }

                    break;

                default:
                    if (isAsc)
                    {
                        list = list.OrderBy(p => p.Name).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(p => p.Name).ToList();
                    }
                    break;

            }


            int count = list.Count;
            list = list.Skip(number * page).Take(number).ToList();
            return Json(new { list, count }, JsonRequestBehavior.AllowGet);
        }

    }
}
