public static class Gigasecond
{
    private const double GigaSecond = 1_000_000_000;
    public static DateTime Add(DateTime moment) => moment.AddSeconds(GigaSecond);

}