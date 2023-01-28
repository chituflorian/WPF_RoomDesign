using System;
using System.Windows.Input;

namespace WPF_Design.ViewModels.Commands
{
    public class BaseCommand<T> : ICommand
    {
        private readonly Action<T> _task;
        private readonly Func<T, bool> _canExecute;


        public BaseCommand(Action<T> action, Func<T, bool> canExecute = null)
        {
            _task = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _task((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute((T)parameter);
        }
    }
}
