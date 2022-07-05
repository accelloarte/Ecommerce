namespace ECommerce.Dto.Request;

//public class LoginDtoRequest
//{
//    public string UserName { get; set; }
//    public string Password { get; set; }
//}

public record LoginDtoRequest(string UserName, string Password);