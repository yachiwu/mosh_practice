using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mosh_practice.Models;
using mosh_practice.Models.ViewModel;




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
            // var customers = _context.Customers.Include(c=>c.MembershipType).ToList();  //Query all the customer entity and related  MembershipType entity
            //return View(customers);
            return View();
        }
       
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null) { return HttpNotFound(); }
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel //remember to add "using mosh_practice.Models.ViewModel;"
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost] //限定Save這個action只能是使用HttpPost進來
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewmodel);
            };
            
        }
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //判斷此id的customer是否有資料
            if (customer == null){
                return HttpNotFound();
            }

            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}