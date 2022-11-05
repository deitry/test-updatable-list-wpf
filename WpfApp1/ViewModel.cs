using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1;

public sealed class ViewModel : INotifyPropertyChanged
{
    public ViewModel()
    {
        DataManagerInstance = (Application.Current as App)!.DataManagerInstance;
    }

    public List<string> MyItems => _myItems;
    public List<char> AvailableComboBoxItems => DataManagerInstance.AvailableComboBoxItems;

    private List<string> _myItems = new List<string> { "initialized", "default", "values" };
    private char _mySelectedChar = DataManager.NotAValue;
    private readonly DataManager DataManagerInstance;

    public char MySelectedChar
    {
        get => _mySelectedChar;
        set
        {
            _mySelectedChar = value;

            SetField(ref _myItems, DataManagerInstance.GetListByChar(value), nameof(MyItems));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
