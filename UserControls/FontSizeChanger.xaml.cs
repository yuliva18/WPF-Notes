using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes.UserControls
{
    /// <summary>
    /// Логика взаимодействия для FontSizeChanger.xaml
    /// </summary>
    public partial class FontSizeChanger : UserControl
    {
        public static readonly DependencyProperty RangeProperty = DependencyProperty.Register("Range", typeof(TextRange), typeof(FontSizeChanger), new PropertyMetadata(RangeChangedCallback));
        static readonly DependencyProperty SizeCollectionProperty = DependencyProperty.Register("SizeCollection", typeof(ObservableCollection<int>), typeof(FontSizeChanger));

        ObservableCollection<int> _sizeCollection = new ObservableCollection<int>() { 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        public TextRange Range { get => (TextRange)GetValue(RangeProperty); set { SetValue(RangeProperty, value); } }
        public ObservableCollection<int> SizeCollection { get => (ObservableCollection<int>)GetValue(SizeCollectionProperty); set { SetValue(SizeCollectionProperty, value); } }

        public FontSizeChanger()
        {
            InitializeComponent();
            SizeCollection = _sizeCollection;
        }

        private int GetActualSize()
        {
            return (int)Math.Round((Double)Range.GetPropertyValue(FontSizeProperty) * 0.75);
        }

        private void ShowSize(int size)
        {
            combobox1.Text = size.ToString();
        }

        private void ShowActualSize()
        {
            try
            {
                int size = GetActualSize();
                ShowSize(size);
            }
            catch
            {
                combobox1.SelectedIndex = -1;
            }
        }
        
        private static int GetSizePT(TextRange tr)
        {
            return (int)Math.Round((Double)tr.GetPropertyValue(FontSizeProperty) * 0.75);
        }

        private static void SetSizePT(TextRange tr, double size)
        {
            tr.ApplyPropertyValue(FontSizeProperty, ((int)(size / 0.75)).ToString());
        }

        private static double GetSizePX(TextRange tr)
        {
            return (Double)tr.GetPropertyValue(FontSizeProperty);
        }

        private static void SetSizePX(TextRange tr, double size)
        {
            tr.ApplyPropertyValue(FontSizeProperty, Math.Max(size, 1).ToString());
        }

        private static void RangeChangedCallback (DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FontSizeChanger fs = (FontSizeChanger)sender;
            TextRange r = (TextRange)e.NewValue;
            fs.ShowActualSize();
        }

        private void Button_UP_Click(object sender, RoutedEventArgs e)
        {
            int len = Range.Text.Length;
            TextPointer start = Range.Start;
            TextPointer end;
            TextRange tr;
            while (len > 0 && start.GetNextInsertionPosition(LogicalDirection.Forward) != null)
            {
                end = start.GetNextInsertionPosition(LogicalDirection.Forward);
                tr = new TextRange(start, end);
                double size = GetSizePX(tr);
                size = getNextSize(size);
                SetSizePX(tr, size);
                start = end;
                len--;
            }
            ShowActualSize();
        }

        private void Button_DOWN_Click(object sender, RoutedEventArgs e)
        {
            int len = Range.Text.Length;
            TextPointer start = Range.Start;
            TextPointer end;
            TextRange tr;
            while (len > 0 && start.GetNextInsertionPosition(LogicalDirection.Forward) != null)
            {
                end = start.GetNextInsertionPosition(LogicalDirection.Forward);
                tr = new TextRange(start, end);
                double size = GetSizePX(tr);
                size = getPreviousSize(size);
                SetSizePX(tr, size);
                start = end;
                len--;
            }
            ShowActualSize();
        }

        private void combobox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = combobox1.Text;
            try
            {
                int val = Int32.Parse(combobox1.Text);
                if (Range != null)
                {
                    SetSizePT(Range, val);
                }
                ShowSize(val);
            }
            catch {
                ShowActualSize();
            }
        }

        private int getNextSize(double val1)
        {
            int val = (int)Math.Ceiling(val1 * 0.75);
            double i = SizeCollection.FirstOrDefault(x => x > val);
            if (i == 0) i = (val / 10) * 10 + 10;
            else if (val < SizeCollection[0]) i = val + 1;
            return (int)Math.Round(i / 0.75);
        }

        private int getPreviousSize(double val1)
        {
            int val = (int)Math.Ceiling(val1 * 0.75);
            double i = SizeCollection.LastOrDefault(x => x < val);
            if (i == 0) i = Math.Max(val - 1, 1);
            else if (val > SizeCollection[SizeCollection.Count - 1]) i = Math.Max(SizeCollection[SizeCollection.Count - 1], val - 10);
            return (int)Math.Round(i / 0.75);
        }
    }
}
