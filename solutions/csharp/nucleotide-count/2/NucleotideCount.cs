public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var set = new HashSet<char>("ACGT");
        if (sequence.Any(c => !set.Contains(c)))
            throw new ArgumentException(sequence);

        return set.ToDictionary(
            c => c,
            c => sequence.Count(cs => cs == c)
        );
    }
}