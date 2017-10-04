using MobildeShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;

namespace MobildeShop.Controllers
{
    public class CustomersAPIController : ApiController
    {
        private MobileShopEntities db = new MobileShopEntities();
        // GET: api/CustomersAPI
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/CustomersAPI/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        // POST: api/CustomersAPI
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.id }, customer);
        }

        // PUT: api/CustomersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.id == id) > 0;
        }
    }
}
