using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1;

public class ComboBoxItemConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null) return 'm';

        return value switch
        {
            ComboBoxItem { Content: string s } => s,
            char c => c,
            string s => s.First(),
            _ => throw new NotSupportedException()
        };
    }
}
