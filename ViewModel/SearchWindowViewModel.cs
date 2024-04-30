using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TestTask.Model;
using TestTask.Model.Core;

namespace TestTask.ViewModel
{
    public class SearchWindowViewModel : INotifyPropertyChanged
    {
        public Window _window { get; set; }
        private string _number;
        public string Number
        {
            get => _number;
            set
            {
                if(value != null)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public ICommand Success
        {
            get
            {
                return new ActionCommand(() =>
                {
                    if(BigInteger.TryParse(_number, out var num))
                    {
                        DataFinder.SearchNumber = num;
                        _window.DialogResult = true;
                    }
                    else _window.DialogResult = false;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
