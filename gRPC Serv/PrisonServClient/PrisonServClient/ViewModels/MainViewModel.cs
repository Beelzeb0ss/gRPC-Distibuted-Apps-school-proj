using Grpc.Net.Client;
using GrpcClientStuff;
using PrisonService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GrpcClientStuff;
using System.Collections.ObjectModel;
using PrisonServClient.Models;

namespace PrisonServClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private GrpcClient client;

        private PrisonersViewModel prisonersVM;
        public PrisonersViewModel PrisonersVM
        {
            get
            {
                return prisonersVM;
            }
        }

        private LocationsViewModel locationsVM;
        public LocationsViewModel LocationsVM
        {
            get
            {
                return locationsVM;
            }
        }

        private JobsViewModel jobsVM;
        public JobsViewModel JobsVM
        {
            get
            {
                return jobsVM;
            }
        }

        private WorkersViewModel workersVM;
        public WorkersViewModel WorkersVM
        {
            get
            {
                return workersVM;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainViewModel()
        {
            client = new GrpcClient("https://localhost:5001");
            prisonersVM = new PrisonersViewModel(this);
            locationsVM = new LocationsViewModel(this);
            jobsVM = new JobsViewModel(this);
            workersVM = new WorkersViewModel(this);
            LoadViewModels();
        }

        public async Task LoadViewModels()
        {
            await client.Start();
            prisonersVM.grpcClient = client;
            locationsVM.grpcClient = client;
            jobsVM.grpcClient = client;
            workersVM.grpcClient = client;
            await prisonersVM.LoadPrisoners();
            await workersVM.LoadWorkers();
            await locationsVM.LoadAllLocations();
            await jobsVM.LoadAllJobs();
            prisonersVM.LoadPrisonerLocations();
            workersVM.LoadWorkerLocationsAndJobs();
            locationsVM.LoadNumberOfPrisonersAndWorkers();
        }

        public async Task ReloadAll()
        {
            await prisonersVM.LoadPrisoners();
            await workersVM.LoadWorkers();
            await locationsVM.LoadAllLocations();
            await jobsVM.LoadAllJobs();
            prisonersVM.LoadPrisonerLocations();
            workersVM.LoadWorkerLocationsAndJobs();
            locationsVM.LoadNumberOfPrisonersAndWorkers();
        }

    }
}
