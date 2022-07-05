using ECommerce.Dto.Request;
using ECommerce.Services;
using ECommerceAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(FilterUser))]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // GET api/Customers?filter=valor
        // GET api/Customers?filter=valor&page=1&rows=2
        // GET api/Customers?filter=valor&page=1&rows=20
        // GET api/Customers

        [HttpGet]
        public async Task<IActionResult> Get(string? filter, int page = 1, int rows = 2)
        {
            var response = await _service.ListAsync(filter, page, rows);

            var value = new
            {
                Exito = response.Success,
                Respuesta = response.Collection
            };
            return Ok(value);
        }

        // GET api/Customers/1

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetByIdAsync(id);

            return response.Success ? Ok(response) : NotFound(response);
        }
        
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var response = await _service.GetByEmailAsync(email);

            return response.Success ? Ok(response) : NotFound(response);
        }

        // POST api/Customers + jsonBody

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return Created($"api/Customers/{response.Result}", response);
        }

        // PUT api/Customers/1 + jsonBody

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CustomerDtoRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        // DELETE api/Customers/1 

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

    }
}
