using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mosh_practice.Models;

namespace mosh_practice.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //建立ApplicationDbContext以連接資料庫
        public CustomersController()
        {
            _context = new ApplicationDbContext(); //初始化
        }
        protected override void Dispose(bool disposing) //釋放非受控資源
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
       
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) { return HttpNotFound(); }
            return View(customer);
        }
    }
}