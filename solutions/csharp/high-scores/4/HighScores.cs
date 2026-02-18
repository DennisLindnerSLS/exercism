using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class HighScores
{
    private List<int> _highScores = new();
    public HighScores(List<int> list)
    {
        _highScores = list;
    }

    public IEnumerable<int> Scores() => new ReadOnlyCollection<int>(_highScores);

    public int Latest() => _highScores.LastOrDefault();

    public int PersonalBest() => _highScores.Max();

    public IEnumerable<int> PersonalTopThree() => new ReadOnlyCollection<int>(_highScores.OrderByDescending(x => x).Take(3).ToList());

}