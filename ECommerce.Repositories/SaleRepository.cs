using System.Linq.Expressions;
using ECommerce.DataAccess;
using ECommerce.Entities;
using ECommerce.Entities.Infos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly ECommerceDbContext _context;

    public SaleRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    private static Expression<Func<Sale, InvoiceInfo>> GetSelector()
    {
        return p => new InvoiceInfo
        {
            Id = p.InvoiceId,
            InvoiceNumber = p.InvoiceNumber,
            CustomerName = $"{p.Customer.FirstName} {p.Customer.LastName}",
            SaleDate = p.SaleDate.ToString("yyyy-MM-dd"),
            TotalAmount = p.TotalSale,
            PaymentMethod = p.PaymentMethod.ToString(),
        };
    }

    public async Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectAsync(string documentNumber, int page, int rows)
    {
        Expression<Func<Sale, bool>> filter = x =>
            x.Customer.DocumentNumber.Equals(documentNumber);

        var collection = await _context.Set<Sale>()
            .Include(x => x.Customer)
            .AsNoTracking()
            .Where(filter)
            .OrderBy(p => p.InvoiceNumber)
            .Skip((page - 1) * rows)
            .Take(rows)
            .Select(GetSelector())
            .ToListAsync();

        var total = await _context.Set<Sale>()
            .AsNoTracking()
            .Where(filter)
            .CountAsync();

        return (collection, total);
    }

    public async Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectAsync(DateTime dateInit, DateTime dateEnd, int page, int rows)
    {
        Expression<Func<Sale, bool>> filter = x => dateInit >= x.SaleDate && dateEnd <= x.SaleDate;

        var collection = await _context.Set<Sale>()
           .Include(x => x.Customer)
           .AsNoTracking()
           .Where(filter)
           .OrderByDescending(p => p.SaleDate)
           .ThenBy(p => p.InvoiceNumber)
           .Skip((page - 1) * rows)
           .Take(rows)
           .Select(GetSelector())
           .ToListAsync();

        var total = await _context.Set<Sale>()
            .AsNoTracking()
            .Where(filter)
            .CountAsync();

        return (collection, total);
    }

    public async Task<(ICollection<InvoiceInfo> Collection, int Total)> SelectByInvoiceNumberAsync(string invoiceNumber, int page, int rows)
    {
        Expression<Func<Sale, bool>> filter = x => x.InvoiceNumber.Contains(invoiceNumber);

        var collection = await _context.Set<Sale>()
           .Include(x => x.Customer)
           .AsNoTracking()
           .Where(filter)
           .OrderByDescending(p => p.SaleDate)
           .Skip((page - 1) * rows)
           .Take(rows)
           .Select(GetSelector())
           .ToListAsync();

        var total = await _context.Set<Sale>()
            .AsNoTracking()
            .Where(filter)
            .CountAsync();

        return (collection, total);
    }

    public async Task<ICollection<SaleDetailInfo>> SelectDetailsAsync(int saleId)
    {
        //return await _context.Set<SaleDetail>()
        //    .Include(p => p.Product)
        //    .AsNoTracking()
        //    .Where(p => p.SaleIdFk == saleId)
        //    .Select(p => new SaleDetailInfo
        //    {
        //        Id = p.SaleDetailId,
        //        ItemNumber = p.ItemNumber,
        //        ProductName = p.Product.Name,
        //        Quantity = p.Quantity,
        //        UnitPrice = p.UnitPrice,
        //        Total = p.TotalSale
        //    })
        //    .ToListAsync();

        var collection = _context.Set<SaleDetailInfo>()
            .FromSqlRaw("EXECUTE dbo.uspSelectDetails @saleId = {0}", saleId);

        return await collection.ToListAsync();

    }

    public async Task<Sale> CreateAsync(Sale sale)
    {
        var number = await _context.Set<Sale>().CountAsync() + 1;
        sale.InvoiceNumber = $"F{number:0000}";

        await _context.Database.BeginTransactionAsync();

        await _context.Set<Sale>().AddAsync(sale);
        return sale;
    }

    public async Task CreateSaleDetailAsync(SaleDetail saleDetail)
    {
        await _context.Set<SaleDetail>().AddAsync(saleDetail);
    }

    public async Task CommitTransactionAsync()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task<ICollection<ReportInfo>> GetReportsAsync(DateTime dateInit, DateTime dateEnd)
    {
        //var collection = await _context.Set<SaleDetail>()
        //    .Include(p => p.Product)
        //    .Include(p => p.Sale)
        //    .AsNoTracking()
        //    .Where(p => dateInit <= p.Sale.SaleDate && dateEnd >= p.Sale.SaleDate)
        //    .GroupBy(x => x.Product.Name)
        //    .Select(p => new ReportInfo
        //    {
        //        ProductName = p.Key,
        //        TotalSale = p.Sum(x => x.TotalSale)
        //    })
        //    .ToListAsync();

        var collection = _context.Set<ReportInfo>()
            .FromSqlRaw(@"SELECT ProductName, TotalSale 
FROM vReporteVentas WHERE SaleDate BETWEEN {0} AND {1}
ORDER BY 2", dateInit, dateEnd)
            .ToList();

        return await Task.FromResult(collection);
    }
}