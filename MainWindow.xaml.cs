using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> mycl { get; set; } = new ObservableCollection<Note>();
        private readonly object _sync = new object();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //BindingOperations.EnableCollectionSynchronization(mycl, _sync);
            mycl.Add(new Note(1, "Заметка 1", "Текст мой текст", DateTime.Now.ToString()));
            mycl.Add(new Note(2, "Заметка 2", "Текст мой текст", DateTime.Now.ToString()));
            mycl.Add(new Note(3, "Заметка 3", "Текст мой текст", DateTime.Now.ToString()));
            mycl.Add(new Note(4, "Заметка 4", "Текст мой текст", DateTime.Now.ToString()));
            mycl.Add(new Note(5, "Заметка 5", "Текст мой текст", DateTime.Now.ToString()));
            mycl.Add(new Note(6, "Заметка 6", "Текст мой текст", DateTime.Now.ToString()));
            mycl[0].IsSelected = true;
            ChangeNote();
        }

        public void onCl(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mycl.Count; i++)
            {
                mycl[i].IsSelected = false;
            }
            var n = sender as NotePanel;
            var id = n.Id;
            var a = mycl.First(x => x.Id == id);
            a.IsSelected = true;
            ChangeNote();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null) { note.Title = textBox.Text; }
        }

        private void ChangeNote()
        {
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            textbox1.Text = note.Title;
            textbox2.Text = note.Body;
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null) { note.Body = textBox.Text; }
        }
    }
}