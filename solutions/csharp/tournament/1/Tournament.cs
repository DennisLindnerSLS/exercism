public static class Tournament
{
    private class TeamResult
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int Points => Wins * 3 + Draws;
        public int MatchesPlayed => Wins + Losses + Draws;
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        var gameTable = new Dictionary<string, TeamResult>();
        using StreamReader reader = new(inStream);

        while (reader.Peek() != -1)
        {
            var line = reader.ReadLine();
            if (line == null)
                return;

            var gameResult = line.Split(';');

            addResultToDictionary(gameTable, gameResult);
        }

        var sortedDict = gameTable
            .OrderByDescending(x => x.Value.Points)
            .ThenBy(x => x.Key);
        
        using StreamWriter writer = new(outStream);
        writer.Write("Team                           | MP |  W |  D |  L |  P");
        foreach (var kv in sortedDict)
        {
            writer.Write("\n");
            writer.Write(String.Format("{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}", kv.Key, kv.Value.MatchesPlayed, kv.Value.Wins, kv.Value.Draws, kv.Value.Losses, kv.Value.Points));
        }
    }

    private static void addResultToDictionary(IDictionary<string, TeamResult> gameTable, string[] gameResult) {

        if (gameResult is not [var teamName, var opponentName, var result])
            throw new ArgumentException("Expected exactly 3 fields: team;opponent;result");

        if (!gameTable.ContainsKey(teamName))
            gameTable.Add(teamName, new TeamResult { Wins = 0, Losses = 0, Draws = 0 });

        if (!gameTable.ContainsKey(opponentName))
            gameTable.Add(opponentName, new TeamResult { Wins = 0, Losses = 0, Draws = 0 });

        switch (result)
        {
            case "win":
                gameTable[teamName].Wins++;
                gameTable[opponentName].Losses++;
                break;
            case "loss":
                gameTable[teamName].Losses++;
                gameTable[opponentName].Wins++;
                break;
            case "draw":
                gameTable[teamName].Draws++;
                gameTable[opponentName].Draws++;
                break;
            default: break;
        }
    }
}
