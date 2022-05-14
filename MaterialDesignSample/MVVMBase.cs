using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Utility.MVVMBase
{
    public class MVVMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        virtual internal protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //protected void SetProperty<T>(ref T propField, T value, Expression<Func<T>> expr)
        //{
        //    var bodyExpr = expr.Body as System.Linq.Expressions.MemberExpression;
        //    if (bodyExpr == null)
        //    {
        //        throw new ArgumentException("Expression must be a MemberExpression!", "expr");
        //    }
        //    var propInfo = bodyExpr.Member as PropertyInfo;
        //    if (propInfo == null)
        //    {
        //        throw new ArgumentException("Expression must be a PropertyExpression!", "expr");
        //    }
        //    var propName = propInfo.Name;
        //    propField = value;
        //    this.OnPropertyChanged(propName);
        //}
        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return;

            storage = value;
            this.OnPropertyChanged(propertyName);
        }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute)
            {
                _execute = execute;
            }
            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                _canExecute = canExecute;
                _execute = execute;
            }

            public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

            public void Execute(object parameter) => _execute();

            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
        }
    }
}
