using System.ComponentModel;
using System.Windows;
using TestTask.Model.Core;
using TestTask.ViewModel;

namespace TestTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            this.Closing += (s, e) =>
            {
                SQLCommands.Disconnect();
            };
        }
    }
}
