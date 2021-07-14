using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using mosh_practice.App_Start;
using mosh_practice.Dtos;
using mosh_practice.Models;

namespace mosh_practice.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private MapperConfiguration config;
        private IMapper iMapper;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper();
        }
        //GET/api/customers 查看所有顧客
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customerQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query)) {
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));
            }
            var customerDtos = customerQuery
                .ToList()
                .Select(iMapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }
        //GET/api/customer/1 查看特定顧客
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(iMapper.Map<Customer, CustomerDto>(customer));
        }
        //POST/api/customers 新增顧客
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = iMapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        //PUT/api/customers/1 修改顧客
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            iMapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();

        }
        //DELETE/api/customers/1 刪除顧客
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
