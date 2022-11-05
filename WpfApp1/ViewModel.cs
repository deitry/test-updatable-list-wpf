using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1;

/// <summary>
/// ViewModel behind MainWindow
/// </summary>
public sealed class ViewModel : INotifyPropertyChanged
{
    public ViewModel()
    {
        // NOTE: null-coalescing is for preview in design time
        DataManagerInstance = (Application.Current as App)?.DataManagerInstance ?? new DataManager();
    }

    public List<string> MyListItems => DataManagerInstance.GetListByChar(_mySelectedChar);
    public List<char> AvailableComboBoxItems => DataManagerInstance.AvailableComboBoxItems;

    private char _mySelectedChar = DataManager.NotAValue;
    private readonly DataManager DataManagerInstance;

    public char MySelectedChar
    {
        get => _mySelectedChar;
        set
        {
            _mySelectedChar = value;
            OnPropertyChanged(nameof(MyListItems));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
