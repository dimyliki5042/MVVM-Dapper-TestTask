using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestTask.Model;
using TestTask.Model.Core;
using TestTask.View;

namespace TestTask.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<MainDataModel> _mainData = SQLCommands.TakeData();
        public List<MainDataModel> MainData
        {
            get => _mainData;
            set
            {
                _mainData = value;
                OnPropertyChanged("MainData");
            }
        }

        public ICommand TakeData
        {
            get
            {
                return new ActionCommand(() =>
                {
                    MainData = SQLCommands.TakeData();
                });
            }
        }

        public ICommand Search
        {
            get
            {
                return new ActionCommand(() =>
                {
                    SearchWindow searchWindow = new SearchWindow();
                    if (searchWindow.ShowDialog() == true)
                    {
                        MainData = DataFinder.FindForNumber();
                    }
                    else
                    {
                        ErrorWindow errorWindow = new ErrorWindow(Errors.ErrorsList[2]);
                        errorWindow.ShowDialog();
                    }
                });
            }
        }

        public ICommand StreetSearch
        {
            get
            {
                return new ActionCommand(() =>
                {
                    StreetsWindow streetsWindow = new StreetsWindow();
                    streetsWindow.ShowDialog();
                });
            }
        }

        public ICommand Export
        {
            get
            {
                return new ActionCommand(() =>
                {
                    ExportCSV.Export(MainData);
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
