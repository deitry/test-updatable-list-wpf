using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                0 => MakeList('a', 3),
                1 => MakeList('b', 5),
                2 => MakeList('c', 7),
                _ => throw new ArgumentOutOfRangeException(nameof(MySelectedItemIndex)),
            };

            OnPropertyChanged(nameof(MyItems));
        }
    }

    private static List<string> MakeList(char seed, int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => Enumerable.Repeat(seed, i))
            .Select(e => string.Join("", e))
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
