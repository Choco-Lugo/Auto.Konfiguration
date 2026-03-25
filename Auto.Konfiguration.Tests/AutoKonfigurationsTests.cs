using Auto.Konfiguration.BApplication.BusinessLogic;
using Auto.Konfiguration.Domain.Entities;
using FluentAssertions;

namespace Auto.Konfiguration.Tests
{
    public class AutoKonfigurationsTests
    {
        private readonly CalculatePrice _calculatePrice = new();

        [Fact]
        public void Calculate_Price()
        {
            //Arrange
            var config = new CarConfiguration()
            {
                Engine = new Engine { Price = 3000 },
                Paint = new Paint { Price = 1000 },
                Rims = new Rims { Price = 500 },
                OptionalEquipment =
                {
                    new OptionalEquipment { Price = 200 },
                    new OptionalEquipment { Price = 300 }
                }
            };

            //Act
            var result = _calculatePrice.Price(config);

            //Assert
            result.Should().Be(5000);
        }
    }
}
