using MobildeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MobildeShop.Controllers
{
    public class OrdersAPIController : ApiController
    {
        private MobileShopEntities db = new MobileShopEntities();

        // POST: api/ProductsAPI
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.id }, order);
        }
    }
}
