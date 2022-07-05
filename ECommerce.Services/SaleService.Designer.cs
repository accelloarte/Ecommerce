using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;

namespace ECommerce.Services;

public partial class SaleService 
{
    public async Task<BaseResponseGeneric<ICollection<SaleDetailDtoResponse>>> SelectDetails(int saleId)
    {
        var response = new BaseResponseGeneric<ICollection<SaleDetailDtoResponse>>();

        try
        {
            var collection = await _repository.SelectDetailsAsync(saleId);

            response.Result = collection
                .Select(x => _mapper.Map<SaleDetailDtoResponse>(x))
                .ToList();

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
        }

        return response;
    }

    public async Task<BaseResponseGeneric<int>> CreateAsync(SaleDtoRequest request)
    {
        var response = new BaseResponseGeneric<int>();

        try
        {
            var entity = new Sale()
            {
                CustomerFk = request.CustomerId,
                PaymentMethod = (PaymentMethod)request.PaymentMethod,
                SaleDate = DateTime.Today,
                TotalSale = request.Details.Sum(p => p.UnitPrice * p.Quantity)
            };

            var sale = await _repository.CreateAsync(entity);

            var counter = 0;

            foreach (var product in request.Details)
            {
                counter++;
                var saleDetail = new SaleDetail
                {
                    Sale = sale,
                    ItemNumber = counter,
                    ProductIdentifier = product.ProductId,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    TotalSale = product.UnitPrice * product.Quantity
                };

                await _repository.CreateSaleDetailAsync(saleDetail);

                await _kardexRepository.RegisterMovement(product.ProductId, (long)product.Quantity, MovementType.Out);
            }

            await _repository.CommitTransactionAsync();

            response.Result = sale.InvoiceId;
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            await _repository.RollBackTransactionAsync();
        }

        return response;
    }

    public async Task<BaseResponseGeneric<ICollection<ReportDtoResponse>>> SelectReportAsync(string dateInit, string dateEnd)
    {
        var response = new BaseResponseGeneric<ICollection<ReportDtoResponse>>();

        try
        {
            var collection =
                await _repository
                    .GetReportsAsync(Convert.ToDateTime(dateInit), Convert.ToDateTime(dateEnd));

            response.Result = collection
                .Select(x => _mapper.Map<ReportDtoResponse>(x))
                .ToList();

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