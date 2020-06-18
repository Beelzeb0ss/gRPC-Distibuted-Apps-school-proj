using Grpc.Core;
using Grpc.Net.Client;
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
    class PrisonersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public GrpcClient grpcClient;

        private MainViewModel mvm;

        private ObservableCollection<Prisoner> prisoners = new ObservableCollection<Prisoner>();
        public ObservableCollection<Prisoner> Prisoners
        {
            get
            {
                return prisoners;
            }
        }

        private Prisoner selectedPrisoner;
        public Prisoner SelectedPrisoner
        {
            get
            {
                return selectedPrisoner;
            }
            set
            {
                if(selectedPrisoner == value)
                {
                    return;
                }
                selectedPrisoner = value;
                OnPropertyChanged("SelectedPrisoner");
                OnPropertyChanged("EditPrisonerVisibility");
            }
        }

        public Visibility EditPrisonerVisibility
        {
            get
            {
                if(SelectedPrisoner != null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Hidden;
            }
        }

        private CommandHandler newPrisonerCommand;
        public ICommand NewPrisonerCommand
        {
            get
            {
                if(newPrisonerCommand == null)
                {
                    newPrisonerCommand = new CommandHandler(NewSelectedPrisoner, null);
                }
                return newPrisonerCommand;
            }
        }

        private CommandHandler savePrisonerCommand;
        public ICommand SavePrisonerCommand
        {
            get
            {
                if(savePrisonerCommand == null)
                {
                    savePrisonerCommand = new CommandHandler(SavePrisoner, null);
                }
                return savePrisonerCommand;
            }
        }

        private CommandHandler removePrisonerCommand;
        public ICommand RemovePrisonerCommand
        {
            get
            {
                if(removePrisonerCommand == null)
                {
                    removePrisonerCommand = new CommandHandler(RemovePrisoner, null);
                }
                return removePrisonerCommand;
            }
        }

        private CommandHandler searchPrisonersCommand;
        public ICommand SearchPrisonersCommand
        {
            get
            {
                if(searchPrisonersCommand == null)
                {
                    searchPrisonersCommand = new CommandHandler(SearchPrisoners, null);
                }
                return searchPrisonersCommand;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void NewSelectedPrisoner(object obj)
        {
            SelectedPrisoner = new Prisoner();
        }

        private void SavePrisoner(object obj)
        {
            if(SelectedPrisoner == null) { return; }
            if(selectedPrisoner.Id == 0)
            {
                AddPrisoner(selectedPrisoner);
            }
            else
            {
                UpdatePrisoner(selectedPrisoner);
            }
        }

        private void RemovePrisoner(object obj)
        {
            if (SelectedPrisoner == null || SelectedPrisoner.Id == 0) { return; }
            DeletePrisoner(selectedPrisoner);
        }

        private void SearchPrisoners(object obj)
        {
            TextBox tb = (TextBox)obj;
            string para = tb.Text;
            SearchPrisonersByName(para);
        }

        private async Task AddPrisoner(Prisoner p)
        {
            try
            {
                await grpcClient.AddPrisoner(ConversionStuff.PrisonerToMessage(p));
                await LoadPrisoners();
                LoadPrisonerLocations();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task UpdatePrisoner(Prisoner p)
        {
            try
            {
                await grpcClient.UpdatePrisoner(ConversionStuff.PrisonerToMessage(p));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DeletePrisoner(Prisoner p)
        {
            try
            {
                await grpcClient.DeletePrisoner(new IdMessage { Id = p.Id});
                await LoadPrisoners();
                LoadPrisonerLocations();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task SearchPrisonersByName(string para)
        {
            var result = await grpcClient.GetPrisonersByName(new SearchParamMessage { Value = para });
            if (result == null) { return; }
            ClearPrisoners();
            foreach (PrisonerMessage p in result.Prisoners)
            {
                prisoners.Add(ConversionStuff.MessageToPrisoner(p));
            }
            LoadPrisonerLocations();
        }

        public PrisonersViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
        }

        public async Task LoadPrisoners()
        {
            var result = await grpcClient.GetAllPrisoners();
            if(result == null) { return; }
            ClearPrisoners();
            foreach (PrisonerMessage p in result.Prisoners)
            {
                prisoners.Add(ConversionStuff.MessageToPrisoner(p));
            }
        }

        public void LoadPrisonerLocations()
        {
            foreach(Prisoner p in prisoners)
            {
                p.Location = mvm.LocationsVM.Locations.FirstOrDefault(l => l.Id == p.LocationId);
            }
        }

        public void ClearPrisoners()
        {
            prisoners.Clear();
        }
    }
}
