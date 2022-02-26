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
        private Action<object> _execute;

        private Predicate<object> _canExecute;


        public ActionCommand(Action<object> execute) : this(execute, DefaultCanExecute)
        {

        }
        public ActionCommand(Action<object> execute, Predicate<object> canExecute)
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
            return (this._canExecute != null && this._canExecute(parameter));
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        private static bool DefaultCanExecute(object paramter)
        {
            return true;
        }
    }
}
