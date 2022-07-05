using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using ECommerce.Repositories;

namespace ECommerce.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponseGenericCollection<CategoryDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2)
    {
        var response = new BaseResponseGenericCollection<CategoryDtoResponse>();

        var tuple = await _repository.GetCollectionAsync(filter ?? string.Empty, page, rows);

        var query = tuple.Collection
            .Select(x => new CategoryDtoResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            })
            .ToList();

        response.Collection = query;
        response.TotalPages = Utils.GetTotalPages(tuple.Total, rows); ;
        response.Success = true;

        return response;
    }

    public async Task<BaseResponseGeneric<CategoryDtoResponse>> GetByIdAsync(int id)
    {
        var response = new BaseResponseGeneric<CategoryDtoResponse>();

        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            response.Success = false;
            return response;
        }

        response.Result = new CategoryDtoResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
        response.Success = true;

        return response;
    }

    public async Task<BaseResponseGeneric<int>> CreateAsync(CategoryDtoRequest request)
    {
        var response = new BaseResponseGeneric<int>();

        var entity = new Category
        {
            Name = request.Name,
            Description = request.Description,
        };

        response.Result = await _repository.CreateAsync(entity);
        response.Success = true;

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, CategoryDtoRequest request)
    {
        var response = new BaseResponse();

        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            entity.Name = request.Name;
            entity.Description = request.Description;

            await _repository.UpdateAsync();
            response.Success = true;
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        var response = new BaseResponse();

        await _repository.DeleteAsync(id);
        response.Success = true;

        return response;
    }
}