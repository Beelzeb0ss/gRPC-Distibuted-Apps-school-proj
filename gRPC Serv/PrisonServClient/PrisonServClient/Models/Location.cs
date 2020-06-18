using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrisonServClient.Models
{
    class Location : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int id;
        protected string name;
        protected int prisonersInLocation;
        protected int workersInLocation;
        protected int posX;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(id == value)
                {
                    return;
                }

                id = value;

                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name == value)
                {
                    return;
                }

                name = value;

                OnPropertyChanged("Name");
            }
        }

        public int PrisonersInLocation
        {
            get
            {
                return prisonersInLocation;
            }
            set
            {
                if(prisonersInLocation == value)
                {
                    return;
                }

                prisonersInLocation = value;

                OnPropertyChanged("PrisonersInLocation");
            }
        }

        public int WorkersInLocation
        {
            get
            {
                return workersInLocation;
            }
            set
            {
                if(workersInLocation == value)
                {
                    return;
                }

                workersInLocation = value;

                OnPropertyChanged("WorkersInLocation");
            }
        }

        public int PosX
        {
            get
            {
                return posX;
            }
            set
            {
                if(posX == value)
                {
                    return;
                }

                posX = value;

                OnPropertyChanged("PosX");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Location() { }

        public Location(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
