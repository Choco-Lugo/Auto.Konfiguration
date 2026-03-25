using Auto.Konfiguration.BApplication.Interface;
using Auto.Konfiguration.Domain.Entities;

namespace Auto.Konfiguration.BApplication.BusinessLogic
{
    public class CalculatePrice : ICalculatePrice
    {
        public decimal Price(CarConfiguration config)
        {
            decimal price = 0;

            if (config.Engine != null)
                price += config.Engine.Price;

            if (config.Rims != null)
                price += config.Rims.Price;

            if (config.Paint != null)
                price += config.Paint.Price;

            price += config.OptionalEquipment.Sum(x => x.Price);

            return price;
        }
    }
}
