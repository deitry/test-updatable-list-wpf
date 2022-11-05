using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1;

public class ComboBoxItemConverter : IValueConverter
{
    /// <summary>
    /// binded property > View
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// View > binded property
    /// </summary>
    public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        // NOTE: can be during Window initialization if FallbackValue is not set
        if (value is null)
            return DataManager.NotAValue;

        return value switch
        {
            ComboBoxItem { Content: string s } => s,
            char c => c,
            string s => s.First(),
            _ => throw new NotSupportedException()
        };
    }
}
