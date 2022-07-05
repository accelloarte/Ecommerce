using System.Security.Claims;
using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : ControllerBase
{
    private readonly ISaleService _service;

    public SalesController(ISaleService service)
    {
        _service = service;
    }

    // GET api/sales

    [HttpGet]
    [Authorize(Roles = Constants.MixedRoles)]
    [ProducesResponseType(typeof(BaseResponseGenericCollection<SaleDtoResponse>), 200)]
    public async Task<IActionResult> Get(
        string? initialDate,
        string? finalDate,
        string? documentNumber,
        string? invoiceNumber,
        int page = 1, int rows = 10)
    {
        BaseResponseGenericCollection<SaleDtoResponse> response;

        if (!string.IsNullOrEmpty(initialDate) && !string.IsNullOrEmpty(finalDate))
            response = await _service.SelectAsync(initialDate, finalDate, page, rows);
        else if (!string.IsNullOrEmpty(documentNumber))
            response = await _service.SelectAsync(documentNumber, page, rows);
        else
            response = await _service.SelectByInvoiceNumberAsync(invoiceNumber ?? string.Empty, page, rows);

        return Ok(response);
    }


    // GET api/Sales/1/details

    [HttpGet("{saleId:int}/details")]
    public async Task<IActionResult> SelectDetails(int saleId)
    {
        return Ok(await _service.SelectDetails(saleId));
    }

    // GET api/Sales/report?dateInit=2022-01-01&dateEnd=2022-05-30

    [HttpGet("report")]
    [Authorize(Roles = Constants.AdminRole)]
    public async Task<IActionResult> SelectReport(string dateInit, string dateEnd)
    {
        return Ok(await _service.SelectReportAsync(dateInit, dateEnd));
    }

    [HttpPost]
    public async Task<IActionResult> Post(SaleDtoRequest request)
    {
        var response = await _service.CreateAsync(request);

        if (response.Success)
            return Created("GetById", response);
        return BadRequest(response);
    }

    // GET: api/Sales/listsales
    [HttpGet("listsales")]
    public async Task<IActionResult> ListSales()
    {
        var documentNumber = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        var expirationDate = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration);

        if (expirationDate != null && DateTime.Parse(expirationDate.Value) < DateTime.Now)
            return Unauthorized();

        if (documentNumber == null)
            return BadRequest();

        return Ok(await _service.SelectAsync(documentNumber.Value, 1, 200));
    }
}