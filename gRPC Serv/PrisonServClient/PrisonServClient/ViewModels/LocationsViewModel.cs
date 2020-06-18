using GrpcClientStuff;
using PrisonServClient.Models;
using PrisonServClient.Models.Utility;
using PrisonServClient.ViewModels.Utility;
using PrisonService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrisonServClient.ViewModels
{
    class LocationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public GrpcClient grpcClient;

        private MainViewModel mvm;

        private ObservableCollection<Location> locations = new ObservableCollection<Location>();
        public ObservableCollection<Location> Locations
        {
            get
            {
                return locations;
            }
        }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {
                if(selectedLocation == value)
                {
                    return;
                }

                selectedLocation = value;
                OnPropertyChanged("SelectedLocation");
                OnPropertyChanged("EditLocationVisibility");
            }
        }

        public Visibility EditLocationVisibility
        {
            get
            {
                if(SelectedLocation != null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Hidden;
            }
        }

        private CommandHandler newLocationCommand;
        public ICommand NewLocationCommand
        {
            get
            {
                if(newLocationCommand == null)
                {
                    newLocationCommand = new CommandHandler(NewSelectedLocation, null);
                }
                return newLocationCommand;
            }
        }

        private CommandHandler saveLocationCommand;
        public ICommand SaveLocationCommand
        {
            get
            {
                if(saveLocationCommand == null)
                {
                    saveLocationCommand = new CommandHandler(SaveLocation, null);
                }
                return saveLocationCommand;
            }
        }

        private CommandHandler removeLocationCommand;
        public ICommand RemoveLocationCommand
        {
            get
            {
                if(removeLocationCommand == null)
                {
                    removeLocationCommand = new CommandHandler(RemoveLocation, null);
                }
                return removeLocationCommand;
            }
        }

        private CommandHandler searchLocationsCommand;
        public ICommand SearchLocationsCommand
        {
            get
            {
                if(searchLocationsCommand == null)
                {
                    searchLocationsCommand = new CommandHandler(SearchLocations, null);
                }
                return searchLocationsCommand;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void NewSelectedLocation(object obj)
        {
            SelectedLocation = new Location();
        }

        private void SaveLocation(object obj)
        {
            if (SelectedLocation == null) { return; }
            if (selectedLocation.Id == 0)
            {
                AddLocationAsync(selectedLocation);
            }
            else
            {
                UpdateLocationAsync(selectedLocation);
            }
        }

        private void RemoveLocation(object obj)
        {
            if (SelectedLocation == null || SelectedLocation.Id == 0) { return; }
            DeleteLocationAsync(selectedLocation);
        }

        private void SearchLocations(object obj)
        {
            TextBox tb = (TextBox)obj;
            string para = tb.Text;
            SearchLocationsByName(para);
        }

        private async Task AddLocationAsync(Location l)
        {
            try
            {
                await grpcClient.AddLocation(ConversionStuff.LocationToMessage(l));
                await mvm.ReloadAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task UpdateLocationAsync(Location l) 
        {
            try
            {
                await grpcClient.UpdateLocation(ConversionStuff.LocationToMessage(l));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DeleteLocationAsync(Location l)
        {
            try
            {
                await grpcClient.DeleteLocation(new IdMessage { Id = l.Id });
                await mvm.ReloadAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task SearchLocationsByName(string para)
        {
            var result = await grpcClient.GetLocationsByName(new SearchParamMessage { Value = para });
            ClearLocations();
            foreach (LocationMessage l in result.Locations)
            {
                locations.Add(ConversionStuff.MessageToLocation(l));
            }
        }

        public LocationsViewModel(MainViewModel mvm) 
        {
            this.mvm = mvm;
        }

        public async Task LoadAllLocations()
        {
            var result = await grpcClient.GetAllLocations();
            ClearLocations();
            if (result == null) { return; }
            foreach (LocationMessage l in result.Locations)
            {
                locations.Add(ConversionStuff.MessageToLocation(l));
            }
        }

        public void LoadNumberOfPrisonersAndWorkers()
        {
            foreach (Location l in locations)
            {
                l.PrisonersInLocation = mvm.PrisonersVM.Prisoners.Count(p => p.LocationId == l.Id);
                l.WorkersInLocation = mvm.WorkersVM.Workers.Count(w => w.LocationId == l.Id);
            }
            for(int i = 1; i<=locations.Count; i++)
            {
                locations[i-1].PosX = i * 100;
            }
        }

        private void ClearLocations()
        {
            locations.Clear();
        }
    }
}
