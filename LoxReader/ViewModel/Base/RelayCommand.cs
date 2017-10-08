
using System;
using System.Windows.Input;

namespace LoxReader
{
    class RelayCommand : ICommand
    {

        #region Public Events
        /// <summary>
        /// The event thats fired the when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => {};
        #endregion

        #region Private Properties

        // The action to run
        private Action action;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        #endregion

        #region CanExecute

        // If the command can be executed.
        // Always allows execute.
        public bool CanExecute(object parameter)
        {
            return true;
        }

        #endregion

        #region Execute

        // Execute the command
        public void Execute(object parameter)
        {
              
            this.action();
        }

        #endregion

    }
}
