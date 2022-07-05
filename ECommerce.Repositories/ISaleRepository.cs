using ECommerce.Entities;
using ECommerce.Entities.Infos;

namespace ECommerce.Repositories;

public interface ISaleRepository
{
    Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectAsync(string documentNumber, int page, int rows);
    Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectAsync(DateTime dateInit, DateTime dateEnd, int page, int rows);
    Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectByInvoiceNumberAsync(string invoiceNumber, int page, int rows);

    Task<ICollection<SaleDetailInfo>> SelectDetailsAsync(int saleId);

    Task<Sale> CreateAsync(Sale sale);

    Task CreateSaleDetailAsync(SaleDetail saleDetail);

    Task CommitTransactionAsync();

    Task RollBackTransactionAsync();

    Task<ICollection<ReportInfo>> GetReportsAsync(DateTime dateInit, DateTime dateEnd);
}