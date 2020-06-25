using PersonalData.Gui.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class AddEmployeeViewModel : BaseViewModel<Employee> {

        public AddEmployeeViewModel() : base(null) {
            this.Model = new Employee();
            this.mDepartment = new Department();
            this.MaritalStatuses = new ObservableCollection<string>(new List<string>() { "Free", "Married", "Divorced" });
            this.Genders = new ObservableCollection<string>(new List<string>() { "Male", "Female" });
            this.Departments = new ObservableCollection<Department>(mDepartment.GetAllDepartments());
            this.InsertCommand = new RelayCommand(this.Insert);
        }

        public AddEmployeeViewModel(Employee employee) : base (employee) {
            this.mFirstName = Model.Names.FirstOrDefault(n => n.NameType == Alias.AliasType.FirstName).FullName;
            this.SecondName = Model.Names.FirstOrDefault(n => n.NameType == Alias.AliasType.SecondName).FullName;
            this.PatronymicName = Model.Names.FirstOrDefault(n => n.NameType == Alias.AliasType.Patronymic).FullName;
            this.mGender = Model.Gender.ToString();
            this.MaritalStatuses = new ObservableCollection<string>(new List<string>() { "Free", "Married", "Divorced" });
            this.Genders = new ObservableCollection<string>(new List<string>() { "Male", "Female" });
            this.Departments = new ObservableCollection<Department>(mDepartment.GetAllDepartments());
            this.InsertCommand = new RelayCommand(this.Insert);
        }

        public void Insert() {

            Employee.MaritalStatusType maritalStatusType = new Employee.MaritalStatusType();
            Enum.TryParse<Employee.MaritalStatusType>(this.MaritalStatus, out maritalStatusType);

            Employee.GenderType genderType = new Employee.GenderType();
            Enum.TryParse<Employee.GenderType>(this.Gender, out genderType);

            this.Model.Insert(FirstName, SecondName, PatronymicName, genderType, maritalStatusType, DateTime.Now, Department);
        }

        public ICommand InsertCommand { get; set; }

        private string mFirstName;
        public string FirstName {
            get {
                return mFirstName;
            }
            set {
                if (this.mFirstName == value) {
                    return;
                }
                this.mFirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string mSecondName;
        public string SecondName {
            get {
                return mSecondName;
            }
            set {
                if (this.mSecondName == value) {
                    return;
                }
                this.mSecondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        private string mPatronymicName;
        public string PatronymicName {
            get {
                return mPatronymicName;
            }
            set {
                if (this.mPatronymicName == value) {
                    return;
                }
                this.mPatronymicName = value;
                OnPropertyChanged(nameof(PatronymicName));
            }
        }

        public ObservableCollection<string> Genders { get; set; }
        private string mGender;
        public string Gender {
            get {
                return mGender;
            }
            set {
                if (this.mGender == value) {
                    return;
                }
                this.mGender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public ObservableCollection<string> MaritalStatuses { get; set;}
        private string mMaritalStatus;
        public string MaritalStatus {
            get {
                return mMaritalStatus;
            }
            set {
                if (this.mMaritalStatus == value) {
                    return;
                }
                this.mMaritalStatus = value;
                OnPropertyChanged(nameof(MaritalStatus));
            }
        }

        public ObservableCollection<Department> Departments { get; set; }
        private Department mDepartment;
        public Department Department {
            get {
                return mDepartment;
            }
            set {
                if (this.mDepartment == value) {
                    return;
                }
                this.mDepartment = value;
                OnPropertyChanged(nameof(Department));
            }
        }
    }
}
