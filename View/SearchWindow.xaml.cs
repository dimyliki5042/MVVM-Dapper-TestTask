using System.Windows;
using TestTask.ViewModel;

namespace TestTask.View
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            DataContext = new SearchWindowViewModel()
            {
                _window = this
            };
        }
    }
}
