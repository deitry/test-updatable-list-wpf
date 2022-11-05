using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WpfApp1;

public class ViewModel : INotifyPropertyChanged
{
    public const char NotAValue = '\0';

    private List<string> _myItems = new List<string> { "initialized", "default", "values" };
    private char _mySelectedChar;

    public List<string> MyItems => _myItems;

    public char MySelectedChar
    {
        get => _mySelectedChar;
        set
        {
            _mySelectedChar = value;
            if (value != NotAValue)
                SetField(ref _myItems, MakeList(value), nameof(MyItems));
        }
    }

    private static int CountByValue(char seed)
    {
        return seed switch
        {
            'a' => 3,
            'b' => 5,
            'c' => 7,
            _ => 0,
        };
    }

    private static List<string> MakeList(char seed)
    {
        var count = CountByValue(seed);
        return Enumerable.Range(1, count)
            .Select(i => new string(seed, i))
            .ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
