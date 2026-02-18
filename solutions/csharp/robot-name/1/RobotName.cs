public static class RobotNameLibrary
{
    private static HashSet<string> _names = new();

    public static bool AddName(string name) => _names.Add(name);

    public static bool NamesAvailable() => _names.Count() <= 676_000;
}

public class Robot
{
    private string? _name = null;
    public string Name
    {
        get
        {
            return _name ?? generateName();
        }
    }

    public void Reset()
    {
        _name = null;
    }

    private string generateName()
    {
        var rand = new Random();
        _name = "";

        do
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < 2)
                    _name += Convert.ToChar(rand.Next(26) + 65);
                else
                    _name += Convert.ToChar(rand.Next(10) + 48);
            }
        } while (RobotNameLibrary.AddName(_name) == false && RobotNameLibrary.NamesAvailable());
        return _name;
    }
}