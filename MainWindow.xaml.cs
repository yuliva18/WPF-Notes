﻿using System.Text;
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
using System.Diagnostics;
using System.IO;
using Notes.UserControls;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Note> mycl { get; set; } = new ObservableCollection<Note>();
        private TextRange _selectedText;
        public TextRange SelectedText {
            get => _selectedText;
            set { _selectedText = value; NotifyPropertyChanged(); }
        }
        NoteIdEqualityComparer noteIdEqualityComparer = new NoteIdEqualityComparer();
        Db db;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            db = new Db();
            db.CreateTableIfNotExist();
            mycl = db.SelectAll();
            SelectFisrt();
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
            RichTextBox? textBox = sender as RichTextBox;
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null && textBox != null) { note.Title = textBox.Document; db.UpdateNote(note); }
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox? textBox = sender as RichTextBox;
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null && textBox != null) { note.Body = textBox.Document; db.UpdateNote(note); }
        }

        private void ChangeNote()
        {
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null)
            {
                textbox1.Document = note.Title;
                textbox2.Document = note.Body;
            }
        }

        private void AddNote()
        {
            db.InsertNote();
            ObservableCollection<Note> tmp = db.SelectAll();
            Note[] d = tmp.Except(mycl, noteIdEqualityComparer).ToArray();
            if (d != null)
            {
                for (int i = 0; i < d.Count(); i++) mycl.Add(d[i]);
            }
        }

        private void SelectFisrt()
        {
            for (int i = 0; i < mycl.Count; i++)
            {
                mycl[i].IsSelected = false;
            }
            if (mycl.Count > 0) mycl[0].IsSelected = true;
            ChangeNote();
        }

        private void SetBold(RichTextBox richTextBox)
        {
            TextRange tr = richTextBox.Selection;
            TextPointer end = tr.Start.GetNextContextPosition(LogicalDirection.Forward);
            if (end == null) { return; }
            tr = new TextRange(tr.Start, end);
            if ((FontWeight)tr.GetPropertyValue(FontWeightProperty) == FontWeights.Bold)
            {
                richTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Regular);
            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            }
        }

        private void SetItalic(RichTextBox richTextBox)
        {
            TextRange tr = richTextBox.Selection;
            TextPointer end = tr.Start.GetNextContextPosition(LogicalDirection.Forward);
            if (end == null) { return; }
            tr = new TextRange(tr.Start, end);
            if ((FontStyle)tr.GetPropertyValue(FontStyleProperty) == FontStyles.Italic)
            {
                richTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            }
        }

        private void SetFontSize(RichTextBox richTextBox, int value)
        {
            richTextBox.Selection.ApplyPropertyValue(FontSizeProperty, value.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNote();
            SelectFisrt();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetBold(textbox1);
            SetBold(textbox2);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetItalic(textbox1);
            SetItalic(textbox2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Note? note = mycl.FirstOrDefault(x => x.IsSelected == true);
            if (note != null)
            {
                db.DeleteNote(note);
                mycl.Remove(note);
                if (mycl.Count == 0) { AddNote(); }
                SelectFisrt();
            }
        }

        private void NumericUpDown_ValueChanged(object sender, RoutedEventArgs e)
        {
            NumericUpDown numUD = (NumericUpDown)sender;
            int val = numUD.Value;
            SetFontSize(textbox1, val);
            SetFontSize(textbox2, val);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void textbox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedText = new TextRange(textbox1.Selection.Start, textbox1.Selection.End);
        }

        private void textbox2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedText = new TextRange(textbox2.Selection.Start, textbox2.Selection.End);
        }

        private void textbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}