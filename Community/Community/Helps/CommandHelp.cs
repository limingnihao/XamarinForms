using System;
using System.Windows.Input;

namespace Community.Helps
{
    public class CommandHelp<T> : ICommand
    {
		readonly Action<T> _execute = null;
		readonly Func<bool> _canExecute = null;


		public CommandHelp(Action<T> execute, Func<bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			_execute = execute;
			_canExecute = canExecute;
		}

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}


		public void Execute(object parameter)
		{
			_execute((T)parameter);
		}


    }
}
