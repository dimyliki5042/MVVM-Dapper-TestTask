using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTask.ViewModel
{
    public class ErrorWindowViewModel : INotifyPropertyChanged
    {
        public ErrorWindowViewModel(string[] error)
        {
            Title = error[0];
            Message = error[1];
        }
        public ErrorWindowViewModel(string title, string message)
        {
            Title = title;
            Message = message;
        }

        private string _title;
        private string _message;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged("Message");
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
