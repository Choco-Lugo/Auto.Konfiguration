using Auto.Konfiguration.APresentation.Navigation;
using Auto.Konfiguration.BApplication.Interface;
using Auto.Konfiguration.Domain.Entities;
using Auto.Konfiguration.Domain.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Konfiguration.APresentation.ViewModels
{
    public partial class CarCompleteModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IAppDbContextService _appDbContext;

        [ObservableProperty]
        private CarConfiguration config = new();

        [ObservableProperty]
        private string inputUrl = string.Empty;

        [ObservableProperty]
        private string generatedUrl = string.Empty;

        public CarCompleteModel(INavigationService navigationService, IAppDbContextService appDbContext)
        {
            _navigationService = navigationService;
            _appDbContext = appDbContext;
        }

        partial void OnConfigChanged(CarConfiguration value)
        {
            Config = value;
            InputUrl = value.Url;
            generatedUrl = $"https://myapp/config/{value.Url}";
        }

        [RelayCommand]
        private void LoadConfiguration()
        {
            if(string.IsNullOrWhiteSpace(InputUrl))
                return;

            var configDB = _appDbContext.GetConfigurationByUrl(InputUrl);

            if (configDB == null)
                return;

            Config = configDB;

        }

        [RelayCommand]
        private void BackConfiguration() 
        {
            _navigationService.NavigateTo<CarKonfigurationModel>();
        }
    }
}
