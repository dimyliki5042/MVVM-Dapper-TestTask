using System.Windows;
using TestTask.ViewModel;

namespace TestTask.View
{
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string[] error)
        {
            InitializeComponent();
            DataContext = new ErrorWindowViewModel(error);
        }
        public ErrorWindow(string title, string message)
        {
            InitializeComponent();
            DataContext = new ErrorWindowViewModel(title, message);
        }
    }
}
