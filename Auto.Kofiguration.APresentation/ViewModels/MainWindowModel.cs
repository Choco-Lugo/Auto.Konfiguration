using Auto.Konfiguration.APresentation.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Auto.Konfiguration.APresentation.ViewModels
{
    public partial class MainWindowModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public ObservableObject? CurrentViewModel => _navigationService.CurrentViewModel;

        public MainWindowModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            if (navigationService is ObservableObject nav)
            {
                nav.PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == nameof(NavigationService.CurrentViewModel))
                        OnPropertyChanged(nameof(CurrentViewModel));
                };
            }

            // Start
            _navigationService.NavigateTo<CarKonfigurationModel>();
        }

        [RelayCommand]
        private void NavigateKonfi() => _navigationService.NavigateTo<CarKonfigurationModel>();
    }
}
