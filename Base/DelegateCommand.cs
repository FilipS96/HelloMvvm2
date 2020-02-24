using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMvvm2.Base
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, Task> asyncFunc;

        private readonly Func<object, bool> canExecute;

        public DelegateCommand(Action<object> action)
        {
            this.action = action;
            this.canExecute = (n) => true;
        }
        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
            asyncFunc?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
