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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrisonServClient.ViewModels
{
    class JobsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public GrpcClient grpcClient;

        private MainViewModel mvm;

        private ObservableCollection<Job> jobs = new ObservableCollection<Job>();
        public ObservableCollection<Job> Jobs
        {
            get
            {
                return jobs;
            }
        }

        private Job selectedJob;
        public Job SelectedJob
        {
            get
            {
                return selectedJob;
            }
            set
            {
                if (selectedJob == value)
                {
                    return;
                }

                selectedJob = value;
                OnPropertyChanged("SelectedJob");
                OnPropertyChanged("EditJobVisibility");
            }
        }

        public Visibility EditJobVisibility
        {
            get
            {
                if (SelectedJob != null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Hidden;
            }
        }

        private CommandHandler newJobCommand;
        public ICommand NewJobCommand
        {
            get
            {
                if (newJobCommand == null)
                {
                    newJobCommand = new CommandHandler(NewSelectedJob, null);
                }
                return newJobCommand;
            }
        }

        private CommandHandler saveJobCommand;
        public ICommand SaveJobCommand
        {
            get
            {
                if (saveJobCommand == null)
                {
                    saveJobCommand = new CommandHandler(SaveJob, null);
                }
                return saveJobCommand;
            }
        }

        private CommandHandler removeJobCommand;
        public ICommand RemoveJobCommand
        {
            get
            {
                if (removeJobCommand == null)
                {
                    removeJobCommand = new CommandHandler(RemoveJob, null);
                }
                return removeJobCommand;
            }
        }

        private CommandHandler searchJobsCommand;
        public ICommand SearchJobsCommand
        {
            get
            {
                if(searchJobsCommand == null)
                {
                    searchJobsCommand = new CommandHandler(SearchJobs, null);
                }
                return searchJobsCommand;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void NewSelectedJob(object obj)
        {
            SelectedJob = new Job();
        }

        private void SaveJob(object obj)
        {
            if (SelectedJob == null) { return; }
            if (selectedJob.Id == 0)
            {
                AddJobAsync(selectedJob);
            }
            else
            {
                UpdateJobAsync(selectedJob);
            }
        }

        private void RemoveJob(object obj)
        {
            if (SelectedJob == null || SelectedJob.Id == 0) { return; }
            DeleteJobAsync(selectedJob);
        }

        private void SearchJobs(object obj)
        {
            TextBox tb = (TextBox)obj;
            string para = tb.Text;
            SearchJobsByName(para);
        }

        private async Task AddJobAsync(Job j)
        {
            try
            {
                await grpcClient.AddJob(ConversionStuff.JobToMessage(j));
                await mvm.ReloadAll();////////////////////////////////////////////////////////////
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task UpdateJobAsync(Job j)
        {
            try
            {
                await grpcClient.UpdateJob(ConversionStuff.JobToMessage(j));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DeleteJobAsync(Job j)
        {
            try
            {
                await grpcClient.DeleteJob(new IdMessage { Id = j.Id });
                await mvm.ReloadAll();//////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task SearchJobsByName(string para)
        {
            var result = await grpcClient.GetJobsByName(new SearchParamMessage { Value = para });
            ClearJobs();
            if (result == null) { return; }
            foreach (JobMessage j in result.Jobs)
            {
                jobs.Add(ConversionStuff.MessageToJob(j));
            }
        }

        public JobsViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
        }

        public async Task LoadAllJobs()
        {
            var result = await grpcClient.GetAllJobs();
            ClearJobs();
            if (result == null) { return; }
            foreach (JobMessage j in result.Jobs)
            {
                jobs.Add(ConversionStuff.MessageToJob(j));
            }
        }

        private void ClearJobs()
        {
            jobs.Clear();
        }
    }
}
