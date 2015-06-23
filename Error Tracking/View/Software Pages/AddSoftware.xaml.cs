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
using Error_Tracking.View;

namespace Error_Tracking.View.Software_Pages
{
    /// <summary>
    /// Interaction logic for AddSoftware.xaml
    /// </summary>
    public partial class AddSoftware : Window
    {
        public AddSoftware()
        {
            InitializeComponent();

            // creates a close action, so we can close from multiple button presses
            ViewModel.ProgramViewModels.AddSoftwareViewModel vm = new ViewModel.ProgramViewModels.AddSoftwareViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
        }
    }
}
