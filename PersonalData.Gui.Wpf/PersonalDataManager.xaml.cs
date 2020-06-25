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
    /// Interaction logic for PersonalDataManager.xaml
    /// </summary>
    public partial class PersonalDataManager : Window {
        public PersonalDataManager() {
            InitializeComponent();
        }

        private void EmloyeeListButton_Click(object sender, RoutedEventArgs e) {

            EmployeeListWindow employeeListWindow = new EmployeeListWindow();
            employeeListWindow.Show();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e) {

            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e) {

            AddDepartmentWindow addDepartmentWindow = new AddDepartmentWindow();
            addDepartmentWindow.Show();
        }
    }
}
