public class SpaceAge
{
    private readonly Dictionary<string, double> _orbitalPeriods = new()
    {
        ["Mercury"] = 0.2408467,
        ["Venus"] = 0.61519726,
        ["Earth"] = 1.0,
        ["Mars"] = 1.8808158,
        ["Jupiter"] = 11.862615,
        ["Saturn"] = 29.447498,
        ["Uranus"] = 84.016846,
        ["Neptune"] = 164.79132,
    };

    private double _ageInDays;
    private const double _standardEarthYear = 365.2425;

    public SpaceAge(int seconds)
    {
        _ageInDays = seconds / 86400; //seconds to days conversion 60*60*24
    }

    public double OnEarth() => toPlanetYears("Earth");

    public double OnMercury() => toPlanetYears("Mercury");

    public double OnVenus() => toPlanetYears("Venus");

    public double OnMars() => toPlanetYears("Mars");

    public double OnJupiter() => toPlanetYears("Jupiter");

    public double OnSaturn() => toPlanetYears("Saturn");

    public double OnUranus() => toPlanetYears("Uranus");

    public double OnNeptune() => toPlanetYears("Neptune");

    private double toPlanetYears(string planet) => _ageInDays / (_orbitalPeriods[planet] * _standardEarthYear);
    
}