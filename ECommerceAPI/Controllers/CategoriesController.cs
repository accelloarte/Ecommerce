using ECommerce.Dto.Request;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET api/Categories?filter=valor
        // GET api/Categories?filter=valor&page=1&rows=2
        // GET api/Categories?filter=valor&page=1&rows=20
        // GET api/Categories

        [HttpGet]
        public async Task<IActionResult> Get(string? filter, int page = 1, int rows = 2)
        {
            return Ok(await _service.ListAsync(filter, page, rows));
        }

        // GET api/Categories/1

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetByIdAsync(id);

            return response.Success ? Ok(response) : NotFound(response);
        }

        // POST api/Categories + jsonBody

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return Created($"api/Categorys/{response.Result}", response);
        }

        // PUT api/Categories/1 + jsonBody

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryDtoRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        // DELETE api/Categories/1 

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
