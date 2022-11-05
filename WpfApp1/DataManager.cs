using System.Collections.Generic;
using System.Linq;

namespace WpfApp1;

public class DataManager
{
    public const char NotAValue = '\0';

    public List<char> AvailableComboBoxItems { get; } = new List<char> { 'a', 'b', 'c' };

    private readonly Dictionary<char, List<string>> _mappedLists;

    public DataManager()
    {
        _mappedLists = AvailableComboBoxItems.ToDictionary(c => c, MakeList);
        _mappedLists.Add(NotAValue, new List<string>());
    }

    public List<string> GetListByChar(char c)
    {
        return _mappedLists.TryGetValue(c, out var list)
            ? list
            : new List<string>();
    }

    private static List<string> MakeList(char seed)
    {
        var count = CountByValue(seed);
        return Enumerable.Range(1, count)
            .Select(i => new string(seed, i))
            .ToList();
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
}
