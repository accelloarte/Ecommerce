using ECommerce.Dto.Request;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET api/Products?filter=valor
    // GET api/Products?filter=valor&page=1&rows=2
    // GET api/Products?filter=valor&page=1&rows=20
    // GET api/Products

    [HttpGet]
    public async Task<IActionResult> Get(string? filter, int page = 1, int rows = 2)
    {
        return Ok(await _service.ListAsync(filter, page, rows));
    }

    // GET api/Products/1

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.GetByIdAsync(id);

        return response.Success ? Ok(response) : NotFound(response);
    }

    // POST api/Products + jsonBody

    [HttpPost]
    public async Task<IActionResult> Post(ProductDtoRequest request)
    {
        var response = await _service.CreateAsync(request);

        return Created($"api/Products/{response.Result}", response);
    }

    // PUT api/Products/1 + jsonBody

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductDtoRequest request)
    {
        return Ok(await _service.UpdateAsync(id, request));
    }

    // DELETE api/Products/1 

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}