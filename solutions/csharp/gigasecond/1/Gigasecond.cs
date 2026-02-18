public static class Gigasecond
{
    private const double GigaSecond = 1000000000;
    public static DateTime Add(DateTime moment) => moment.AddSeconds(GigaSecond);

}