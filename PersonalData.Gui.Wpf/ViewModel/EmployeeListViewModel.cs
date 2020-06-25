using PersonalData.Gui.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class EmployeeListViewModel {

        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public EmployeeListViewModel(Organization organization) {
            Employees = new ObservableCollection<EmployeeViewModel>(organization.Employees.Select(e => new EmployeeViewModel(e)));
        }
    }
}
