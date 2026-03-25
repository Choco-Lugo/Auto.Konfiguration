using Auto.Konfiguration.Domain.Entities;

namespace Auto.Konfiguration.BApplication.Interface
{
    public interface ICalculatePrice
    {
        decimal Price(CarConfiguration config);
    }
}
