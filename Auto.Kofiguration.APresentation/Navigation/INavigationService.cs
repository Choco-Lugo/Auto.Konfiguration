using CommunityToolkit.Mvvm.ComponentModel;

namespace Auto.Konfiguration.APresentation.Navigation
{
    public interface INavigationService
    {
        ObservableObject? CurrentViewModel { get; }
        void NavigateTo<TViewModel>(Action<TViewModel>? init = null) where TViewModel : ObservableObject;
    }
}
