using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrisonServClient.Models
{
    class Job : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int id;
        protected string title;

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

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if(title == value)
                {
                    return;
                }

                title = value;

                OnPropertyChanged("Title");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
