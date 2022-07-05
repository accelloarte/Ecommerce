using System.Xml.Serialization;
using ECommerce.Entities;
using ECommerce.Repositories;
using ECommerce.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace ECommerceTest
{
    public class ProductUnitTest : DbContextUnitTest
    {

        [Fact]
        public async Task Product_Pagination_Without_Database()
        {
            // Arrange
            // MOCK

            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetCollectionAsync(It.IsAny<string>(), 1, 10))
                .Returns(async () =>
                {
                    var task = Task.Run(() =>
                    {
                        var list = new List<Product>();

                        return (list, list.Count);
                    });

                    return await task;
                });

            var fileUploader = new Mock<IFileUploader>();
            var logger = new Mock<ILogger<ProductService>>();

            var service = new ProductService(repository.Object, fileUploader.Object, logger.Object);

            // Act

            var actual = await service.ListAsync(string.Empty, 1, 10);

            var expected = 0;

            // Assert

            Assert.Equal(expected, actual.TotalPages);
        }

        [Fact]
        public async Task Product_Pagination_With_Database()
        {
            // Arrange
            var repository = new ProductRepository(Context);
            var fileUploader = new Mock<IFileUploader>();
            var logger = new Mock<ILogger<ProductService>>();

            var service = new ProductService(repository, fileUploader.Object, logger.Object);

            // Act

            var actual = await service.ListAsync(It.IsAny<string>(), 1, 2);

            var expected = 1;

            // Assert

            Assert.Equal(expected, actual.TotalPages);
        }
        
        [Fact]
        public async Task Product_CheckRowsCount_With_Database()
        {
            // Arrange
            var repository = new ProductRepository(Context);
            var fileUploader = new Mock<IFileUploader>();
            var logger = new Mock<ILogger<ProductService>>();

            var service = new ProductService(repository, fileUploader.Object, logger.Object);

            // Act

            var actual = await service.ListAsync(It.IsAny<string>(), 1, 20);

            var expected = 2;

            // Assert
            Assert.NotNull(actual.Collection);
            Assert.Equal(expected, actual.Collection.Count);
        }

        [Fact]
        public async Task Product_GetByIdResult()
        {
            // Arrange
            var repository = new ProductRepository(Context);

            // Act
            var actual = await repository.GetByIdAsync(1);
            var actualNulo = await repository.GetByIdAsync(20);

            // Assert
            Assert.NotNull(actual);
            Assert.Null(actualNulo);
        }
    }
}
