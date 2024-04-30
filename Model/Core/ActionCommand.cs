using System;
using System.Windows.Input;

namespace TestTask.Model.Core
{
    public class ActionCommand : ICommand
    {
        public Action action;

        public ActionCommand(Action action) { this.action = action; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) { this.action(); }
    }
}