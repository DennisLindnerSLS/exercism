using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private readonly Identity admin;

    private IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity("bert@ex.ism", EyeColor.Blue),
            ["Anders"] = new Identity("anders@ex.ism", EyeColor.Brown)
        };

    public Identity Admin => admin; //since Identity is struct its copy by value

    public IDictionary<string, Identity> GetDevelopers() =>
        new ReadOnlyDictionary<string, Identity>(developers);
}

public struct Identity //Small note here you could use readonly struct here
{
    public string Email { get; set; } //and replace set with init

    public string EyeColor { get; set; } //this would entirely prevent someone from changing any value after Initialization

    public Identity(string email, string eyeColor)
    {
        Email = email;
        EyeColor = eyeColor;
    }
    
}
