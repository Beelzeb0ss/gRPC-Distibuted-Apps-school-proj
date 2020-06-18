using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrisonServClient.Models
{
    class Worker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int id;
        protected string fName;
        protected string lName;
        protected int jobId;
        protected Job job;
        protected int locationId;
        protected Location location;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id == value)
                {
                    return;
                }

                id = value;

                OnPropertyChanged("Id");
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                if (fName == value)
                {
                    return;
                }

                fName = value;

                OnPropertyChanged("FName");
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                if (lName == value)
                {
                    return;
                }

                lName = value;

                OnPropertyChanged("LName");
            }
        }

        public int JobId
        {
            get
            {
                return jobId;
            }
            set
            {
                if(jobId == value)
                {
                    return;
                }

                jobId = value;

                OnPropertyChanged("JobId");
            }
        }

        public Job Job
        {
            get
            {
                return job;
            }
            set
            {
                if(job == value)
                {
                    return;
                }

                job = value;
                JobId = job.Id;
                OnPropertyChanged("Job");
            }
        }

        public int LocationId
        {
            get
            {
                return locationId;
            }
            set
            {
                if (locationId == value)
                {
                    return;
                }

                locationId = value;

                OnPropertyChanged("LocationId");
            }
        }

        public Location Location
        {
            get
            {
                return location;
            }
            set
            {
                if(location == value)
                {
                    return;
                }

                location = value;
                if (location != null)
                {
                    LocationId = location.Id;
                }
                OnPropertyChanged("Location");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Worker() { }

        public Worker(int id, string fName, string lName, Job job, Location location)
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.job = job;
            this.location = location;
        }
    }
}
