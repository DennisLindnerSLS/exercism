using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
    {
        1 => "goalie",
        2 => "left back",
        3 or 4 => "center back",
        5 => "right back",
        >= 6 and <= 8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => "UNKNOWN",
    };

    public static string AnalyzeOffField(object report) => report switch
    {
        int => $"There are {(int)report} supporters at the match.",
        string => (string)report,
        Foul => ((Foul)report).GetDescription(),
        Injury => $"Oh no! {((Injury)report).GetDescription()} Medics are on the field.",
        Incident =>  ((Incident)report).GetDescription(),
        Manager manager => manager.Club != null 
            ? $"{manager.Name} ({manager.Club})" 
            : manager.Name,
        _ => ""
    };
}
