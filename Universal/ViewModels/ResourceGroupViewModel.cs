using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Azure;

namespace Universal.ViewModels
{
    public class ResourceGroupViewModel : NotificationBase
    {
        Command _command;
        public Command Command
        {
            get { return _command; }
            set { if (SetProperty(ref _command, value)) RaisePropertyChanged(nameof(Command)); }
        }

        ObservableCollection<Location> Locations;

        public ResourceGroupViewModel()
        {
            Locations = new ObservableCollection<Location>();
        }


        public void UpdateCommand(string name, bool force)
        {
            Command = Generator.CreateResourceGroup(name, force);
        }
    }
}
