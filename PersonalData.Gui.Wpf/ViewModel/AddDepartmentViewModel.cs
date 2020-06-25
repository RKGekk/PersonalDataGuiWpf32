using PersonalData.Gui.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class AddDepartmentViewModel : BaseViewModel<Department> {

        public AddDepartmentViewModel() : base(null) {
            this.Model = new Department();
            this.InsertCommand = new MvvmCommand(
                (param) => this.Insert(),
                (param) => DepartmentName?.Length > 0
            );
        }

        public ICommand InsertCommand { get; set; }

        public void Insert() {
            Model.Insert(DepartmentName);
        }

        private string mDepartmentName;
        public string DepartmentName {
            get {
                return mDepartmentName;
            }
            set {
                if (this.mDepartmentName == value) {
                    return;
                }
                this.mDepartmentName = value;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
    }
}
