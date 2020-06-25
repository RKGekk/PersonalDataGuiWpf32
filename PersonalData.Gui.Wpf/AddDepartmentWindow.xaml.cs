using PersonalData.Gui.Wpf.ViewModel;
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

namespace PersonalData.Gui.Wpf {
    /// <summary>
    /// Interaction logic for AddDepartmentWindow.xaml
    /// </summary>
    public partial class AddDepartmentWindow : Window {

        public AddDepartmentViewModel addDepartmentViewModel { get; set; }

        public AddDepartmentWindow() {
            InitializeComponent();
            this.addDepartmentViewModel = new AddDepartmentViewModel();
            this.DataContext = addDepartmentViewModel;
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e) {
            this.addDepartmentViewModel.Insert();
            this.Close();
        }
    }
}
