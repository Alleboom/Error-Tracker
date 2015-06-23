using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tools
{
    public class RelayCommand : ICommand
    {

        #region Properties
        Action<object> _Execute;
        Predicate<object> _CanExecute;
        #endregion


        #region Contstructors
        /// <summary>
        /// Calls Relay Comamnd with no predicate 
        /// </summary>
        /// <param name="execute">The method that will be executed</param>
        public RelayCommand(Action<object> execute) : this(execute,null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _Execute = execute;
            _CanExecute = canExecute;
            
        }
        #endregion

        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }

        /// <summary>
        /// Monitors if the ability to execute has changed and informs members of the component model
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add {CommandManager.RequerySuggested += value;}
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
        #endregion

    }
}
