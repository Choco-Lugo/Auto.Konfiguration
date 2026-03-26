using Auto.Konfiguration.APresentation.Navigation;
using Auto.Konfiguration.BApplication.BusinessLogic;
using Auto.Konfiguration.BApplication.Interface;
using Auto.Konfiguration.Domain.Entities;
using Auto.Konfiguration.Domain.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Auto.Konfiguration.APresentation.ViewModels
{
    public partial class CarKonfigurationModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IAppDbContextService _appDbContext;

        private readonly ICalculatePrice _calculatePrice;

        public ObservableCollection<Engine> engines { get; set; } = new();
        public ObservableCollection<Paint> paints { get; set; } = new();
        public ObservableCollection<Rims> rims { get; set; } = new();
        public ObservableCollection<OptionalEquipment> extras { get; set; } = new();

        [ObservableProperty]
        private CarConfiguration config = new();

        [ObservableProperty]
        private Engine? selectedEngine;

        [ObservableProperty]
        private Paint? selectedPaint;

        [ObservableProperty]
        private Rims? selectedRims;

        [ObservableProperty]
        private decimal totalPreice;

        public CarKonfigurationModel(INavigationService navigationService, IAppDbContextService appDbContext, ICalculatePrice calculatePrice)
        {
            _navigationService = navigationService;
            _appDbContext = appDbContext;
            _calculatePrice = calculatePrice;

            LoadDB();
        }

        private void LoadDB()
        {
            engines = new ObservableCollection<Engine>(_appDbContext.GetEngines());
            paints = new ObservableCollection<Paint>(_appDbContext.GetPaints());
            rims = new ObservableCollection<Rims>(_appDbContext.GetRims());
            extras = new ObservableCollection<OptionalEquipment>(_appDbContext.GetOptionalEquipment());
        }

        //Berechnungen Preis HH
        partial void OnSelectedEngineChanged(Engine? value)
        {
            Config.Engine = value;
            Config.EngineId = value?.Id ?? 0;

            TotalPreice = _calculatePrice.Price(Config);
        }

        partial void OnSelectedPaintChanged(Paint? value)
        {
            Config.Paint = value;
            Config.PaintId = value?.Id ?? 0;

            TotalPreice = _calculatePrice.Price(Config);
        }

        partial void OnSelectedRimsChanged(Rims? value) 
        {
            Config.Rims = value;
            Config.RimsId = value?.Id ?? 0;

            TotalPreice = _calculatePrice.Price(Config);
        }

        [RelayCommand]
        private void UpdateExtras(IList<object> selectedItems)
        {
            Config.OptionalEquipment.Clear();

            foreach (OptionalEquipment item in selectedItems)
            {
                if (Config.OptionalEquipment.Count >= 5)
                    break;

                Config.OptionalEquipment.Add(item);
            }

            TotalPreice = _calculatePrice.Price(Config);
        }

        //Button Command, Übermittlung Konfiguration
        [RelayCommand]
        private void SaveConfig() 
        {
            Config.Url = Guid.NewGuid().ToString();
            Config.TotalPrice = TotalPreice;

            _appDbContext.SaveConfiguration(Config);

            if (Config.Paint != null && Config.Engine != null)
            {
                _navigationService.NavigateTo<CarCompleteModel>(vm =>
                {
                    vm.Config = Config;
                });
            }
        }
    }
}
