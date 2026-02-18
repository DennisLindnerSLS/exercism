public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException(firstStrand, secondStrand);

        var firstStrandChars = firstStrand.ToCharArray();
        var secondStrandChars = secondStrand.ToCharArray();
        return firstStrandChars.Where((value, idx) => value != secondStrandChars[idx]).Count();
    }
}