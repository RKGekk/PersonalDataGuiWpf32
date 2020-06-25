using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.ViewModel {
    public abstract class ObservableObject<T> : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }

        public virtual void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        protected virtual void OnPropertyChanged(Expression<Func<T, object>> property) {
            if (property == null || property.Body == null) { return; }

            MemberExpression memberExp = property.Body as MemberExpression;
            if (memberExp == null) { return; }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExp.Member.Name));
        }
    }
}
