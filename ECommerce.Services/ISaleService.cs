using ECommerce.Dto.Request;
using ECommerce.Dto.Response;

namespace ECommerce.Services;

public interface ISaleService
{
    Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectAsync(string documentNumber, int page, int rows);
    Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectAsync(string dateInit, string dateEnd, int page, int rows);
    Task<BaseResponseGenericCollection<SaleDtoResponse>> SelectByInvoiceNumberAsync(string invoiceNumber, int page, int rows);

    Task<BaseResponseGeneric<ICollection<SaleDetailDtoResponse>>> SelectDetails(int saleId);

    Task<BaseResponseGeneric<int>> CreateAsync(SaleDtoRequest request);

    Task<BaseResponseGeneric<ICollection<ReportDtoResponse>>> SelectReportAsync(string dateInit, string dateEnd);
}