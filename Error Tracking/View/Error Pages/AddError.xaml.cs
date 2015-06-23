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
using System.Windows.Shapes;

namespace Error_Tracking.View.Error_Pages
{
    /// <summary>
    /// Interaction logic for AddError.xaml
    /// </summary>
    public partial class AddError : Window
    {
        public AddError()
        {
            InitializeComponent();

            // creates a close action, so we can close from multiple button presses
            ViewModel.ErrorViewModels.AddErrorViewModel vm = new ViewModel.ErrorViewModels.AddErrorViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
        }
    }
}
