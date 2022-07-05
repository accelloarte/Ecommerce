using ECommerce.Services;

namespace ECommerceTest
{
    public class UnitTest1
    {
        [Fact]
        public void SumaTest()
        {
            // Arrange
            var a = 5;
            var b = 4;

            // Act
            var suma = a + b;

            var expected = 9;

            // Assert
            Assert.Equal(expected, suma);
        }

        [Fact]
        public void Metodo_De_Paginacion_Test()
        {
            // Arrange
            var rows = 10;
            var count = 100;

            // Act
            var actual = Utils.GetTotalPages(count, rows);
            var expected = 10;

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(200, 10, 20)]
        [InlineData(101, 10, 11)]
        [InlineData(99, 10, 10)]
        [InlineData(-50, 10, 0)]
        public void Metodo_De_Paginacion_Con_Parametros_Test(int total, int rows, int expected)
        {
            // Act
            var actual = Utils.GetTotalPages(total, rows);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}