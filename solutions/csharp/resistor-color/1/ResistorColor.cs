using System.Linq;
public static class ResistorColor
{
    private static readonly Dictionary<string, int> BandColors = new() {
        ["black"] = 0,
        ["brown"] = 1,
        ["red"] = 2,
        ["orange"] = 3,
        ["yellow"] = 4,
        ["green"] = 5,
        ["blue"] = 6,
        ["violet"] = 7,
        ["grey"] = 8,
        ["white"] = 9
    };

    public static int ColorCode(string color)
    {
        if (BandColors.TryGetValue(color, out var val))
            return val;

        return -1;
    }

    public static string[] Colors() => BandColors.Keys.ToArray();
}