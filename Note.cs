using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notes
{
    public class Note : INotifyPropertyChanged
    {
        private Int64 _id;
        public Int64 Id
        {
            get => _id;
            set { _id = value; NotifyPropertyChanged(); }
        }
        private FlowDocument _title;
        public FlowDocument Title {
            get => _title;
            set { _title = value; NotifyPropertyChanged(); } 
        }
        private FlowDocument _body;
        public FlowDocument Body
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

        public Note(Int64 id, FlowDocument title, FlowDocument body, string date, bool isSelected = false) {
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

    public class NoteIdEqualityComparer : IEqualityComparer<Note>
    {
        public bool Equals(Note x, Note y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Note obj) { return obj.Id.GetHashCode(); }
    }
}
