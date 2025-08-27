public class HighScores
{
    private List<int> _highScores = new();
    public HighScores(List<int> list)
    {
        _highScores = list;
    }

    public IList<int> Scores() => _highScores.AsReadOnly();

    public int Latest() => _highScores.LastOrDefault();

    public int PersonalBest() => _highScores.Max();

    public List<int> PersonalTopThree() => _highScores.OrderByDescending(x => x).Take(3).ToList();

}