using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown));
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown));
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("MouseLeftButtonUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
        public int MinValue { get => (int)GetValue(MinValueProperty); set { SetValue(MinValueProperty, value); }}
        public int MaxValue { get => (int)GetValue(MaxValueProperty); set { SetValue(MaxValueProperty, value); }}
        public int Value { get => (int)GetValue(ValueProperty); set { SetValue(ValueProperty, value); } }
        public event RoutedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        public NumericUpDown()
        {
            InitializeComponent();
        }

        private void Button_UP_Click(object sender, RoutedEventArgs e)
        {
            Value = Math.Min(Value + 1, MaxValue);
            RoutedEventArgs eventArgs = new RoutedEventArgs(NumericUpDown.ValueChangedEvent);
            RaiseEvent(eventArgs);
        }

        private void Button_DOWN_Click(object sender, RoutedEventArgs e)
        {
            Value = Math.Max(Value - 1, MinValue);
            RoutedEventArgs eventArgs = new RoutedEventArgs(NumericUpDown.ValueChangedEvent);
            RaiseEvent(eventArgs);
        }
    }
}
