using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IFileUploader _fileUploader;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, IFileUploader fileUploader, ILogger<ProductService> logger)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _logger = logger;
        }

        public async Task<BaseResponseGenericCollection<ProductDtoResponse>> ListAsync(string? filter, int page = 1, int rows = 2)
        {
            var response = new BaseResponseGenericCollection<ProductDtoResponse>();

            var tuple = await _repository.GetCollectionAsync(filter ?? string.Empty, page, rows);

            var query = tuple.Collection
                .Select(x => new ProductDtoResponse
                {
                    ProductId = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Category = x.Category.Name,
                    ProductUrl = x.ProductUrl,
                    UnitPrice = x.UnitPrice
                })
                .ToList();

            response.Collection = query;
            response.TotalPages = Utils.GetTotalPages(tuple.Total, rows); ;
            response.Success = true;

            return response;
        }

        public async Task<BaseResponseGeneric<ProductDtoResponse>> GetByIdAsync(int id)
        {
            var response = new BaseResponseGeneric<ProductDtoResponse>();

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogCritical("No se encontro el registro {id}", id);
                response.Success = false;
                return response;
            }

            _logger.LogInformation("Se leyo el registro con el id {id}", id);

            response.Result = new ProductDtoResponse
            {
                ProductId = entity.Id,
                Name = entity.Name,
                Category = entity.Category.Name,
                Description = entity.Description,
                ProductUrl = entity.ProductUrl,
                UnitPrice = entity.UnitPrice
            };
            response.Success = true;

            return response;
        }

        public async Task<BaseResponseGeneric<int>> CreateAsync(ProductDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            request.ProductUrl = await _fileUploader.UploadFileAsync(request.Base64Image, request.FileName);

            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                UnitPrice = request.UnitPrice,
                CategoryId = request.IdCategory,
                ProductUrl = request.ProductUrl,
                Active = request.Active ?? true,
            };

            response.Result = await _repository.CreateAsync(entity);
            response.Success = true;

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ProductDtoRequest request)
        {
            var response = new BaseResponse();

            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(request.FileName))
                        entity.ProductUrl = await _fileUploader.UploadFileAsync(request.Base64Image, request.FileName);

                    entity.Name = request.Name;
                    entity.Description = request.Description;
                    entity.UnitPrice = request.UnitPrice;
                    entity.CategoryId = request.IdCategory;
                    entity.Active = request.Active ?? true;

                    await _repository.UpdateAsync();
                    response.Success = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error de concurrencia, vuelva a cargar el registro";

                    _logger.LogCritical(ex, "Error de concurrencia");

                    var entry = ex.Entries.Single();

                    foreach (var property in entry.Metadata.GetProperties())
                    {
                        var proposedValue = entry.Property(property.Name).CurrentValue;
                        var previousValue = entry.Property(property.Name).OriginalValue;

                        if (proposedValue?.ToString() != previousValue?.ToString())
                        {
                            _logger.LogWarning("Se intento cambiar la propiedad {name}, con el valor {proposedValue} y el valor original era {previousValue}", property.Name, 
                                proposedValue, 
                                previousValue);
                        }
                    }
                   
                }
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
}