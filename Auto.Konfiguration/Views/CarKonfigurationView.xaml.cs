using Auto.Konfiguration.APresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auto.Konfiguration.Views
{
    /// <summary>
    /// Interaktionslogik für CarKonfigurationView.xaml
    /// </summary>
    public partial class CarKonfigurationView : UserControl
    {
        public CarKonfigurationView()
        {
            InitializeComponent();
        }

        private void Extras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext is CarKonfigurationModel vm)
            {
                vm.UpdateExtrasCommand.Execute(((ListBox)sender).SelectedItems);
            }
        }
    }
}
