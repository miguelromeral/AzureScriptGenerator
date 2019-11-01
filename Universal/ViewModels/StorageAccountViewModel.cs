using Library;
using Library.Azure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.ViewModels
{
    public class StorageAccountViewModel : NotificationBase
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


        string _resourcegroup;
        public string ResourceGroup
        {
            get { return _resourcegroup; }
            set
            {
                if (SetProperty(ref _resourcegroup, value))
                {
                    RaisePropertyChanged(nameof(ResourceGroup));
                    Update();
                }
            }
        }


        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (SetProperty(ref _name, value))
                {
                    RaisePropertyChanged(nameof(Name));
                    Update();
                }
            }
        }

        string _selectedSKU;
        public string SelectedSKU
        {
            get { return _selectedSKU; }
            set
            {
                if (SetProperty(ref _selectedSKU, value))
                {
                    RaisePropertyChanged(nameof(SelectedSKU));
                    Update();
                }
            }
        }

        public ObservableCollection<string> Skus;

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

        public ObservableCollection<string> Locations;


        public StorageAccountViewModel()
        {
            Skus = new ObservableCollection<string>();
            Locations = new ObservableCollection<string>();
            FillSKU();
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
            foreach (var e in list)
            {
                Locations.Add(e);
            }
        }

        private void FillSKU()
        {
            Skus.Clear();
            var list = new List<string>();
            foreach (var sku in (SKU[])Enum.GetValues(typeof(SKU)))
            {
                list.Add(EnumHelper.GetSKUDescription(sku));
            }
            list.Sort();
            foreach (var e in list)
            {
                Skus.Add(e);
            }
        }

        public void Update()
        {
            if (String.IsNullOrEmpty(ResourceGroup) || String.IsNullOrEmpty(Name))
            {
                CreateCommand = null;
                ReadCommand = null;
                UpdateCommand = null;
                DeleteCommand = null;
            }
            else
            {
                if(String.IsNullOrEmpty(SelectedSKU) || String.IsNullOrEmpty(Location))
                {
                    CreateCommand = null;
                }
                else
                {
                    CreateCommand = Generator.CreateStorageAccount(ResourceGroup, Name, EnumHelper.GetSKUByAttribute(SelectedSKU), Location);
                }

                ReadCommand = Generator.ReadStorageAccount(ResourceGroup, Name);
                UpdateCommand = Generator.UpdateStorageAccount(ResourceGroup, Name, SelectedSKU);
                DeleteCommand = Generator.DeleteStorageAccount(ResourceGroup, Name);
            }
        }
    }
}
