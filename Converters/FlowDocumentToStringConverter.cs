using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Documents;

namespace Notes.Converters
{
    public class FlowDocumentToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlowDocument document = (FlowDocument)value;
            string text = new TextRange(document.ContentStart, document.ContentEnd).Text;
            return text.Split("\r\n")[0];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlowDocument document = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add((string)value);
            document.Blocks.Add(paragraph);
            return document;
        }
    }
}
