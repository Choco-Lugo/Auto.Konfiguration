using Auto.Konfiguration.Domain.Entities;
using System.Collections.ObjectModel;

namespace Auto.Konfiguration.Domain.Interfaces
{
    public interface IAppDbContextService
    {
        List<Engine> GetEngines();
        List<Paint> GetPaints();
        List<Rims> GetRims();
        List<OptionalEquipment> GetOptionalEquipment();
    }
}
