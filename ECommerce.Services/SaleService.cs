using AutoMapper;
using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using ECommerce.Repositories;

namespace ECommerce.Services;

public partial class SaleService : ISaleService
{
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;
    private readonly IKardexRepository _kardexRepository;

    public SaleService(ISaleRepository repository, IMapper mapper, IKardexRepository kardexRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _kardexRepository = kardexRepository;
    }

    public async Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectAsync(string documentNumber, int page, int rows)
    {
        var response = new BaseResponseGenericCollection<SaleDtoResponse>();

        try
        {
            var tuple = await _repository.SelectAsync(documentNumber, page, rows);

            response.Collection = tuple.Collection
                .Select(x => _mapper.Map<SaleDtoResponse>(x))
                .ToList();
            response.TotalPages = Utils.GetTotalPages(tuple.Total, rows);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
        }

        return response;
    }

    public async Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectAsync(string dateInit, string dateEnd, int page, int rows)
    {
        var response = new BaseResponseGenericCollection<SaleDtoResponse>();

        try
        {
            var tuple = await _repository.SelectAsync(Convert.ToDateTime(dateInit), 
                Convert.ToDateTime(dateEnd), page, rows);

            response.Collection = tuple.Collection
                .Select(x => _mapper.Map<SaleDtoResponse>(x))
                .ToList();
            response.TotalPages = Utils.GetTotalPages(tuple.Total, rows);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
        }

        return response;
    }

    public async Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectByInvoiceNumberAsync(string invoiceNumber, int page, int rows)
    {
        var response = new BaseResponseGenericCollection<SaleDtoResponse>();

        try
        {
            var tuple = await _repository.SelectByInvoiceNumberAsync(invoiceNumber, page, rows);

            response.Collection = tuple.Collection
                .Select(x => _mapper.Map<SaleDtoResponse>(x))
                .ToList();
            response.TotalPages = Utils.GetTotalPages(tuple.Total, rows);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
        }

        return response;
    }
    
}