using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class MvvmCommand : ICommand {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> executeAction;
        private bool canExecuteCache;

        public MvvmCommand(Action<object> executeAction, Func<object, bool> canExecute) {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            if (CanExecuteChanged != null) {
                CanExecuteChanged(this, new EventArgs());
            }
            return canExecute(parameter);
        }

        public void Execute(object parameter) {
            executeAction(parameter);
        }
    }
}
