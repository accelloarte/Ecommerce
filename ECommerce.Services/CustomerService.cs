using AutoMapper;
using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using ECommerce.Repositories;

namespace ECommerce.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BaseResponseGenericCollection<CustomerDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2)
    {
        var response = new BaseResponseGenericCollection<CustomerDtoResponse>();

        var tuple = await _repository.GetCollectionAsync(filter ?? string.Empty, page, rows);

        var query = tuple.Collection
            //.Select(x => new CustomerDtoResponse
            //{
            //    Id = x.Id,
            //    FullName = $"{x.FirstName} {x.LastName}",
            //    Email = x.Email,
            //    DocumentNumber = x.DocumentNumber,
            //    Dependants = x.Dependants,
            //    Age = (DateTime.Today.Year - x.BirthDate.Year)
            //})
            .Select(x => _mapper.Map<CustomerDtoResponse>(x))
            .ToList();

        response.Collection = query;
        response.TotalPages = Utils.GetTotalPages(tuple.Total, rows);
        response.Success = true;

        return response;
    }

    public async Task<BaseResponseGeneric<CustomerDtoResponse>> GetByIdAsync(int id)
    {
        var response = new BaseResponseGeneric<CustomerDtoResponse>();

        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            response.Success = false;
            return response;
        }

        response.Result = _mapper.Map<CustomerDtoResponse>(entity);
        response.Success = true;

        return response;
    }

    public async Task<BaseResponseGeneric<CustomerDtoResponse>> GetByEmailAsync(string email)
    {
        var response = new BaseResponseGeneric<CustomerDtoResponse>();

        var entity = await _repository.GetByEmailAsync(email);
        if (entity == null)
        {
            response.Success = false;
            return response;
        }

        response.Result = _mapper.Map<CustomerDtoResponse>(entity);
        response.Success = true;

        return response;
    }

    public async Task<BaseResponseGeneric<int>> CreateAsync(CustomerDtoRequest request)
    {
        var response = new BaseResponseGeneric<int>();

        response.Result = await _repository.CreateAsync(_mapper.Map<Customer>(request));
        response.Success = true;

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, CustomerDtoRequest request)
    {
        var response = new BaseResponse();

        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _mapper.Map(request, entity);

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