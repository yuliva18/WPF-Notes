using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для NotePanel.xaml
    /// </summary>
    public partial class NotePanel : UserControl//, INotifyPropertyChanged
    {
        public static DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(int), typeof(NotePanel));
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(NotePanel)/*, new PropertyMetadata(a)*/);
        public static readonly DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(NotePanel));
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(NotePanel));
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(NotePanel)/*, new PropertyMetadata(a)*/);
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("MouseLeftButtonUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NotePanel));

        public bool IsSelected { 
            get => (bool)GetValue(IsSelectedProperty); 
            set { SetValue(IsSelectedProperty, value); } 
        }
        public int Id { get => (int)GetValue(IdProperty); set { SetValue(IdProperty, value); } }
        public String Title { get => (string)GetValue(TitleProperty); set { SetValue(TitleProperty, value); } }
        public String Body { get => (string)GetValue(BodyProperty); set { SetValue(BodyProperty, value); } }
        public String Date { get => (string)GetValue(DateProperty); set { SetValue(DateProperty, value); } }
        public event RoutedEventHandler Click {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        

        public static void a(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //    //NotePanel b = (NotePanel)d;
            //    //PropertyChangedEventHandler h = b.PropertyChanged;
            //    //if (h != null)
            //    //{
            //    //    h(b, new PropertyChangedEventArgs(true.ToString()));
            //    //}
            var val = e.NewValue;
        }


        public NotePanel()
         {
            InitializeComponent();
         }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RoutedEventArgs eventArgs = new RoutedEventArgs(NotePanel.ClickEvent);
            RaiseEvent(eventArgs);
            //PropertyChangedEventHandler h = PropertyChanged;
            //if (h != null)
            //{
            //    h(this, new PropertyChangedEventArgs("IsSelected"));
            //}
            // a(this, new DependencyPropertyChangedEventArgs(IsSelectedProperty, false, true));
            
        }
    }
}
