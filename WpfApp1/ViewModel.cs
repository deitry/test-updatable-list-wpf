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
            switch (value)
            {
                case 0:
                    _myItems = new List<string>() { "a", "aa", "aaa" };
                    break;
                case 1:
                    _myItems = new List<string>() { "b", "bb", "bbb" };
                    break;
                case 2:
                    _myItems = new List<string>() { "c", "cc", "ccc" };
                    break;
            }
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
