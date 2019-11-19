using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movies.Models;

namespace movies.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            var customers = GetCustomers();

            return View(customers);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }

        public ActionResult Details(int id)
        {
            var cust = GetCustomers().SingleOrDefault(x => x.Id == id);

            if (cust == null)
            {
                return HttpNotFound();
            }
               

            return View(cust);
        }

    }
}