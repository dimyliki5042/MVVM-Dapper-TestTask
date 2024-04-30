using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestTask.Model;
using TestTask.Model.Core;

namespace TestTask.ViewModel
{
    public class StreetsWindowViewModel :INotifyPropertyChanged
    {
        private List<StreetSearchModel> _streetGrid = SQLCommands.StreetAbonentCount();
        public List<StreetSearchModel> StreetGrid
        {
            get => _streetGrid;
            set
            {
                _streetGrid = value;
                OnPropertyChanged("StreetGrid");
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
