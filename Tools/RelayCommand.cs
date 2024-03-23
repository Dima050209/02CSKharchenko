using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _02Kharchenko.Tools
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action execute) : this(execute, null)
        {
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = (o) => execute?.Invoke();
            _canExecute = (o) => 
            {
                return canExecute == null ? true : canExecute.Invoke();
            };
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
