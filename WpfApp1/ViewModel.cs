using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1;

public class ViewModel : INotifyPropertyChanged
{
    public List<string> _myItems = new List<string>() { "initialized", "default", "values" };
    private int _mySelectedItemIndex;

    public List<string> MyItems
    {
        get => _myItems;
    }

    public int MySelectedItemIndex
    {
        get => _mySelectedItemIndex;
        set
        {
            _mySelectedItemIndex = value;
            _myItems = value switch
            {
                0 => new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa" },
                1 => new List<string> { "b", "bb", "bbb", "bbbb", "bbbbb" },
                2 => new List<string> { "c", "cc", "ccc", "cccc", "ccccc" },
                _ => throw new ArgumentOutOfRangeException(nameof(MySelectedItemIndex)),
            };

            OnPropertyChanged(nameof(MyItems));
        }
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
