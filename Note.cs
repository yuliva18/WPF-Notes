using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class Note : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; NotifyPropertyChanged(); }
        }
        private string _title;
        public String Title {
            get => _title;
            set { _title = value; NotifyPropertyChanged(); } 
        }
        private string _body;
        public String Body
        {
            get => _body;
            set { _body = value; NotifyPropertyChanged(); }
        }
        private string _date;
        public String Date
        {
            get => _date;
            set { _date = value; NotifyPropertyChanged(); }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; NotifyPropertyChanged(); }
        }

        public Note(int id, string title, string body, string date, bool isSelected = false) {
            Id = id;
            Title = title;
            Body = body;
            Date = date;
            IsSelected = isSelected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
