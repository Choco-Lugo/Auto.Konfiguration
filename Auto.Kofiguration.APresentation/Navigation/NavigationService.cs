using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Konfiguration.APresentation.Navigation
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceProvider _provider;

        private ObservableObject _currentViewModel = null!;
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public NavigationService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void NavigateTo<TViewModel>(Action<TViewModel>? init = null) where TViewModel : ObservableObject
        {
            var vm = _provider.GetRequiredService<TViewModel>();

            // optional: initialisieren (Parameter setzen)
            init?.Invoke(vm);

            CurrentViewModel = vm;
        }
    }
}
