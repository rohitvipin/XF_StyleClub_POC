using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XF_StyleClub_POC.Common
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<object, Task> _action;
        private Task _task;
        private readonly Func<Task> _actionWithOutParameter;

        public AsyncRelayCommand(Func<object, Task> action)
        {
            _action = action;
        }

        public AsyncRelayCommand(Func<Task> actionWithOutParameter)
        {
            _actionWithOutParameter = actionWithOutParameter;
        }

        public bool CanExecute(object parameter) => _task == null || _task.IsCompleted;

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            if (_action != null)
            {
                _task = _action(parameter);
                OnCanExecuteChanged();
                await _task;
                OnCanExecuteChanged();
            }
            else
            {
                _task = _actionWithOutParameter();
                OnCanExecuteChanged();
                await _task;
                OnCanExecuteChanged();
            }
        }

        private void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
