using MudBlazor;

namespace Auto.Konfiguration.Blazor.Theme
{
    public class AppTheme
    {
        public static MudTheme Theme = new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#2196F3",
                Secondary = "#1E1E2F",
                Background = "#F3F6F9",
                Surface = "#FFFFFF",
                AppbarBackground = "#1E1E2F",
                DrawerBackground = "#1E1E2F",
                DrawerText = "#2196F3",
                AppbarText = "#2196F3"
            }
        };
    }
}
