public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var dict = new HashSet<char>("ACGT");
        if (sequence.Any(c => !dict.Contains(c)))
            throw new ArgumentException(sequence);

        return dict.ToDictionary(
            c => c,
            c => sequence.Count(cs => cs == c)
        );
    }
}