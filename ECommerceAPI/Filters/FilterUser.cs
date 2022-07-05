using ECommerce.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceAPI.Filters;

public class FilterUser : IActionFilter
{
    private readonly ILogger<FilterUser> _logger;

    public FilterUser(ILogger<FilterUser> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;

        if (user.Identity == null) return;

        if (user.Identity.IsAuthenticated == false)
        {
            WriteResponse(context, "Usuario no autenticado");
            return;
        }

        var expirationDate = user.Claims.FirstOrDefault(c => c.Type == "exp");

        if (expirationDate != null && 
            DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expirationDate.Value)).LocalDateTime  < DateTime.Now)
        {
            WriteResponse(context, "Token expirado");
        }
    }

    private static void WriteResponse(ActionExecutingContext context, string message)
    {
        context.Result = new JsonResult(new BaseResponse
        {
            Success = false,
            ErrorMessage = message
        });
    }


    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do Nothing
    }
}