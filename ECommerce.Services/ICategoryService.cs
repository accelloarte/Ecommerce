using ECommerce.Dto.Request;
using ECommerce.Dto.Response;

namespace ECommerce.Services;

public interface ICategoryService
{
    Task<BaseResponseGenericCollection<CategoryDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2);

    Task<BaseResponseGeneric<CategoryDtoResponse>> GetByIdAsync(int id);

    Task<BaseResponseGeneric<int>> CreateAsync(CategoryDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, CategoryDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}