using PersonalData.Gui.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class EmployeeViewModel : BaseViewModel<Employee> {

        public EmployeeViewModel(Employee employee) : base(employee) {
            this.mFullName = this.Model.Names[0].FullName;
        }

        private string mFullName;
        public string FullName {
            get {
                return mFullName;
            }
            set {
                if (this.mFullName == value) {
                    return;
                }
                this.mFullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
}
