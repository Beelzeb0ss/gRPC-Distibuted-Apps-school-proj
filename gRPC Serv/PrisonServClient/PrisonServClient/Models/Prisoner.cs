using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrisonServClient.Models
{
    class Prisoner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int id;
        protected string fName;
        protected string lName;
        protected double age;
        protected DateTime sentencedOn;
        protected DateTime releaseDate;
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
                if(id == value)
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
                if(fName == value)
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
                if(lName == value)
                {
                    return;
                }

                lName = value;

                OnPropertyChanged("LName");
            }
        }

        public double Age
        {
            get
            {
                return age;
            }
            set
            {
                if(age == value)
                {
                    return;
                }

                age = value;

                OnPropertyChanged("Age");
            }
        }

        public DateTime SentencedOn
        {
            get
            {
                return sentencedOn;
            }
            set
            {
                if(sentencedOn == value)
                {
                    return;
                }

                sentencedOn = value;

                OnPropertyChanged("SentencedOn");
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                if(releaseDate == value)
                {
                    return;
                }

                releaseDate = value;

                OnPropertyChanged("ReleaseDate");
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

        public Prisoner()
        {

        }

        public Prisoner(int id, string fName, string lName, double age, DateTime sentencedOn, DateTime releaseDate, Location location)
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.age = age;
            this.sentencedOn = sentencedOn;
            this.releaseDate = releaseDate;
            this.location = location;
        }
    }
}
