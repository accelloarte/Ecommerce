namespace ECommerce.Dto.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

public class BaseResponseGeneric<T> : BaseResponse
{
    public T? Result { get; set; }
}

public class BaseResponseGenericCollection<T> : BaseResponse
{
    public ICollection<T>? Collection { get; set; } 
    public int TotalPages { get; set; }
}