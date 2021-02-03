using AutoMapper;
using CBBStoreAPI.Data.Customers;
using CBBStoreAPI.VM.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        #region fields
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        #endregion

        #region implementation
        //GET /customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomersVM>> GetAllCustomers()
        {
            var customers = _customersRepository.GetAllCustomers();
            if (customers.Any())
            {
                return Ok(_mapper.Map<IEnumerable<CustomersVM>>(customers));
            }
            return StatusCode(204, new { message = "No customers found" });
        } 

        //GET /customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomersVM> GetCustomerById(int id)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer == null)
            {
                return StatusCode(404, new { message = "Customer does not exist." });
            }

            return Ok(_mapper.Map<CustomersVM>(customer));
        }

        //POST /customers
        [HttpPost]
        public ActionResult CreateCustomer(CustomersVM model)
        {
            if (ModelState.IsValid)
            {
                _customersRepository.CreateCustomer(_mapper.Map<Models.Customers>(model));
                return StatusCode(201, "Customer has been successfully created.");
            }

            return StatusCode(400, new { message = "There was an error while creating customer." });
        }

        //PUT /customers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(CustomersVM model)
        {
            if (ModelState.IsValid)
            {
                _customersRepository.UpdateCustomer(_mapper.Map<Models.Customers>(model));
                return StatusCode(200, new { message = "Customer has been successfully updated." });
            }
            return BadRequest(model);
        }

        //DELETE /customers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customersRepository.GetCustomerById(id);

            if (customer != null)
            {
                _customersRepository.DeleteCustomer(customer);
                return StatusCode(200, new { message = "Customer has been deleted." });
            }

            return StatusCode(404, new { message = "Customer does not exist." });
        }

        #endregion
    }
}
