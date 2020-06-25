using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class BaseViewModel<T> : ObservableObject<BaseViewModel<T>> where T : class {

        public T model;
        public T Model {
            get => model;
            set {
                if (model == value) {
                    return;
                }
                model = value;
                OnPropertyChanged(vm => vm.Model);
            }
        }

        public BaseViewModel(T model) {
            this.Model = model;
        }
    }
}
