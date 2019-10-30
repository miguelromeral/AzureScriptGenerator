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
        Command _createCommand;
        public Command CreateCommand
        {
            get { return _createCommand; }
            set { if (SetProperty(ref _createCommand, value)) RaisePropertyChanged(nameof(CreateCommand)); }
        }

        public ObservableCollection<string> Locations;

        bool _force;
        public bool Force
        {
            get { return _force; }
            set { if (SetProperty(ref _force, value))
                {
                    RaisePropertyChanged(nameof(Force));
                    UpdateCommand();
                }
            }
        }

        string _name;
        public string Name { get { return _name; } set {
                if (SetProperty(ref _name, value))
                {
                    RaisePropertyChanged(nameof(Name));
                    UpdateCommand();
                }
            } }

        string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (SetProperty(ref _location, value))
                {
                    RaisePropertyChanged(nameof(Location));
                    UpdateCommand();
                }
            }
        }

        public ResourceGroupViewModel()
        {
            Locations = new ObservableCollection<string>();
            FillLocations();
        }
        
        private void FillLocations()
        {
            Locations.Clear();
            var list = new List<string>();
            foreach (var l in (Location[])Enum.GetValues(typeof(Location)))
            {
                list.Add(EnumHelper.GetLocationDescription(l));
            }
            list.Sort();
            foreach(var e in list)
            {
                Locations.Add(e);
            }
        }

        public void UpdateCommand()
        {
            if (String.IsNullOrEmpty(Name))
            {
                CreateCommand = null;
            }
            else
            {
                CreateCommand = Generator.CreateResourceGroup(Name, Force, Location);
            }
        }
    }
}
