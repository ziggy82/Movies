using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movies.Models;

namespace movies.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

       

        public ActionResult Details(int id)
        {
            var cust = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);

            if (cust == null)
            {
                return HttpNotFound();
            }
               

            return View(cust);
        }

    }
}