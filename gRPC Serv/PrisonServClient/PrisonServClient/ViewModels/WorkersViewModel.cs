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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrisonServClient.ViewModels
{
    class WorkersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public GrpcClient grpcClient;

        private MainViewModel mvm;

        private ObservableCollection<Worker> workers = new ObservableCollection<Worker>();
        public ObservableCollection<Worker> Workers
        {
            get
            {
                return workers;
            }
        }

        private Worker selectedWorker;
        public Worker SelectedWorker
        {
            get
            {
                return selectedWorker;
            }
            set
            {
                if (selectedWorker == value)
                {
                    return;
                }
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
                OnPropertyChanged("EditWorkerVisibility");
            }
        }

        public Visibility EditWorkerVisibility
        {
            get
            {
                if (SelectedWorker != null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Hidden;
            }
        }

        private CommandHandler newworkerCommand;
        public ICommand NewWorkerCommand
        {
            get
            {
                if (newworkerCommand == null)
                {
                    newworkerCommand = new CommandHandler(NewSelectedWorker, null);
                }
                return newworkerCommand;
            }
        }

        private CommandHandler saveWorkerCommand;
        public ICommand SaveWorkerCommand
        {
            get
            {
                if (saveWorkerCommand == null)
                {
                    saveWorkerCommand = new CommandHandler(SaveWorker, null);
                }
                return saveWorkerCommand;
            }
        }

        private CommandHandler removeWorkerCommand;
        public ICommand RemoveWorkerCommand
        {
            get
            {
                if (removeWorkerCommand == null)
                {
                    removeWorkerCommand = new CommandHandler(RemoveWorker, null);
                }
                return removeWorkerCommand;
            }
        }

        private CommandHandler searchWorkersCommand;
        public ICommand SearchWorkersCommand
        {
            get
            {
                if(searchWorkersCommand == null)
                {
                    searchWorkersCommand = new CommandHandler(SearchWorkers, null);
                }
                return searchWorkersCommand;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void NewSelectedWorker(object obj)
        {
            SelectedWorker = new Worker();
        }

        private void SaveWorker(object obj)
        {
            if (SelectedWorker == null) { return; }
            if (selectedWorker.Id == 0)
            {
                AddWorker(selectedWorker);
            }
            else
            {
                UpdateWorker(selectedWorker);
            }
        }

        private void RemoveWorker(object obj)
        {
            if (SelectedWorker == null || SelectedWorker.Id == 0) { return; }
            DeleteWorker(selectedWorker);
        }

        private void SearchWorkers(object obj)
        {
            TextBox tb = (TextBox)obj;
            string para = tb.Text;
            SearchWorkersByName(para);
        }

        private async Task AddWorker(Worker w)
        {
            try
            {
                await grpcClient.AddWorker(ConversionStuff.WorkerToMessage(w));
                await LoadWorkers();
                LoadWorkerLocationsAndJobs();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task UpdateWorker(Worker w)
        {
            try
            {
                await grpcClient.UpdateWorker(ConversionStuff.WorkerToMessage(w));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DeleteWorker(Worker w)
        {
            try
            {
                await grpcClient.DeleteWorker(new IdMessage { Id = w.Id });
                await LoadWorkers();
                LoadWorkerLocationsAndJobs();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task SearchWorkersByName(string para)
        {
            var result = await grpcClient.GetWorkersByName(new SearchParamMessage { Value = para });
            if (result == null) { return; }
            ClearWorkers();
            foreach (WorkerMessage w in result.Workers)
            {
                workers.Add(ConversionStuff.MessageToWorker(w));
            }
            LoadWorkerLocationsAndJobs();
        }

        public WorkersViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
        }

        public async Task LoadWorkers()
        {
            var result = await grpcClient.GetAllWorkers();
            if (result == null) { return; }
            ClearWorkers();
            foreach (WorkerMessage w in result.Workers)
            {
                workers.Add(ConversionStuff.MessageToWorker(w));
            }
        }

        public void LoadWorkerLocationsAndJobs()
        {
            foreach (Worker w in workers)
            {
                w.Location = mvm.LocationsVM.Locations.FirstOrDefault(l => l.Id == w.LocationId);
                w.Job = mvm.JobsVM.Jobs.FirstOrDefault(j => j.Id == w.JobId);
            }
        }

        public void ClearWorkers()
        {
            workers.Clear();
        }
    }
}
