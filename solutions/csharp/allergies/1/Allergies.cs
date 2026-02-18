using System.Linq;

[Flags]
public enum Allergen
{
    Eggs = 1 << 0,
    Peanuts = 1 << 1,
    Shellfish = 1 << 2,
    Strawberries = 1 << 3,
    Tomatoes = 1 << 4,
    Chocolate = 1 << 5,
    Pollen = 1 << 6,
    Cats = 1 << 7
}

public class Allergies
{
    private Allergen _allergies;
    public Allergies(int mask)
    {
        var adjustedMask = mask << (32 - 8);
        adjustedMask = adjustedMask >> (32 - 8);

        _allergies = (Allergen)adjustedMask;
    }

    public bool IsAllergicTo(Allergen allergen) =>
        _allergies.HasFlag(allergen);

    public Allergen[] List() =>
        Allergen.GetValues(typeof(Allergen))
            .Cast<Allergen>()
            .Where(x => ((int)_allergies & (int)x) != 0)
            .ToArray();
}