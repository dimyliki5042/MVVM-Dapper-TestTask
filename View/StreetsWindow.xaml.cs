using System.Windows;
using TestTask.ViewModel;

namespace TestTask.View
{
    public partial class StreetsWindow : Window
    {
        public StreetsWindow()
        {
            InitializeComponent();
            DataContext = new StreetsWindowViewModel();
        }
    }
}
