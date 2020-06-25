using PersonalData.Gui.Wpf.Model;
using PersonalData.Gui.Wpf.ViewModel;
using PersonalData.Repository;
using PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Dictionary;
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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window {

        public AddEmployeeViewModel addEmployeeViewModel { get; set; }

        public AddEmployeeWindow() {
            InitializeComponent();
            addEmployeeViewModel = new AddEmployeeViewModel();
            this.DataContext = addEmployeeViewModel;
        }

        public AddEmployeeWindow(Employee employee) {
            InitializeComponent();
            addEmployeeViewModel = new AddEmployeeViewModel(employee);
            this.DataContext = addEmployeeViewModel;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e) {

            addEmployeeViewModel.Insert();
            this.Close();
        }
    }
}
