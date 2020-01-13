using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        private Customer _obj = new Customer();

        // GET: api/Customer

        public CustomerController(ICustomer customer)
        {
            _customer = customer;

        }
        
        [HttpGet]
        [ActionName("GetAllCustomer")]
        public IEnumerable<Customer> GetAll()
        {                        
            return _customer.GetAll(_obj).ToList();            
        }
        
        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        [ActionName("GetCustomer")]
        public Customer Get(int id)
        {
            _obj.CustomerId = id;
            var customer = _customer.Get(_obj);            
            return customer;
        }
        
        // POST: api/Customer
        [HttpPost]
        [ActionName("InsertCustomer")]
        public void Post(Customer obj)
        {
            if (_customer.CheckTaxIdentification(obj.TaxIdentification))
            {
                _customer.Save(obj);
            }
            else
            {
                throw new ArgumentException($"CPF {obj.TaxIdentification} Inválido.");
            }
            
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        [ActionName("UpdateCustomer")]
        public void Put(int id, Customer obj)
        {
            _obj = obj;
            var updateCustomer = _customer.Get(_obj);

            updateCustomer.Address = obj.Address;
            updateCustomer.Age = obj.Age;
            updateCustomer.DateOfBith = obj.DateOfBith;
            updateCustomer.Name = obj.Name;
            updateCustomer.TaxIdentification = obj.TaxIdentification;

            _customer.Update(updateCustomer);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ActionName("DeleteCustomer")]
        public void Delete(int id)
        {
            _obj.CustomerId = id;
            _customer.Delete(_obj);

        }
    }
}
