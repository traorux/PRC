using Microsoft.AspNetCore.Mvc;
using PRC.CORE.Model;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediaService mediaService;

        public CustomerController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public async Task<bool> CreerCustomer(Customer customer)
        {
            return await mediaService.CreateCustomer(customer);
        }


        [HttpPut]
        public async Task<bool> ModifierCustomer(Customer customer)
        {
            return await mediaService.UpdateCustomer(customer);
        }

        [HttpPost]
        public async Task<Customer> SearchCustomer(string customerNumber)
        {
            var customer = await mediaService.SearchCustomer(customerNumber);
            if (customer.DataCustom != null)
            {
                customer.DataCustom.Customer = null;
                return customer;
            }
            else
                return customer;

         
        }

       
        

    }

}
