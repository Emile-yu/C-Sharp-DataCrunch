using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tools
{
    public class ActionCommand : ICommand
    {
        private Action _execute;

        private Func<bool> _canExecute;


        public ActionCommand(Action execute) : this(execute, null)
        {
        }
        public ActionCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._execute != null)
                {
                    CommandManager.RequerySuggested += value;
                }

            }

            remove
            {
                if (this._execute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : this._canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
