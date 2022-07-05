using ECommerce.Dto.Request;
using ECommerce.Dto.Response;

namespace ECommerce.Services;

public interface ICustomerService
{
    Task<BaseResponseGenericCollection<CustomerDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2);

    Task<BaseResponseGeneric<CustomerDtoResponse>> GetByIdAsync(int id);
    
    Task<BaseResponseGeneric<CustomerDtoResponse>> GetByEmailAsync(string email);

    Task<BaseResponseGeneric<int>> CreateAsync(CustomerDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, CustomerDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}