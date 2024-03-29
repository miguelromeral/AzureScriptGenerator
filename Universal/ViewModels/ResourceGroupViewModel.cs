﻿using System;
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

        Command _deleteCommand;
        public Command DeleteCommand
        {
            get { return _deleteCommand; }
            set { if (SetProperty(ref _deleteCommand, value)) RaisePropertyChanged(nameof(DeleteCommand)); }
        }

        Command _readCommand;
        public Command ReadCommand
        {
            get { return _readCommand; }
            set { if (SetProperty(ref _readCommand, value)) RaisePropertyChanged(nameof(ReadCommand)); }
        }

        Command _updateCommand;
        public Command UpdateCommand
        {
            get { return _updateCommand; }
            set { if (SetProperty(ref _updateCommand, value)) RaisePropertyChanged(nameof(Update)); }
        }
        

        public ObservableCollection<string> Locations;

        bool _force;
        public bool Force
        {
            get { return _force; }
            set { if (SetProperty(ref _force, value))
                {
                    RaisePropertyChanged(nameof(Force));
                    Update();
                }
            }
        }

        string _name;
        public string Name { get { return _name; } set {
                if (SetProperty(ref _name, value))
                {
                    RaisePropertyChanged(nameof(Name));
                    Update();
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
                    Update();
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

        public void Update()
        {
            if (String.IsNullOrEmpty(Name))
            {
                CreateCommand = null;
                ReadCommand = null;
                UpdateCommand = null;
                DeleteCommand = null;
            }
            else
            {
                CreateCommand = Generator.CreateResourceGroup(Name, Force, Location);
                ReadCommand = Generator.ReadResourceGroup(Name, Location);
                UpdateCommand = Generator.UpdateResourceGroup(Name);
                DeleteCommand = Generator.DeleteResourceGroup(Name, Force);
            }
        }
    }
}
