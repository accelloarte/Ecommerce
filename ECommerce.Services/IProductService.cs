using ECommerce.Dto.Request;
using ECommerce.Dto.Response;

namespace ECommerce.Services;

public interface IProductService
{
    Task<BaseResponseGenericCollection<ProductDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2);

    Task<BaseResponseGeneric<ProductDtoResponse>> GetByIdAsync(int id);

    Task<BaseResponseGeneric<int>> CreateAsync(ProductDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, ProductDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}