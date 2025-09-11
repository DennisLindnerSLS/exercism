using System.Linq;
public static class Bob
{
    public static string Response(string statement)
    {
        var chars = statement.Trim().ToCharArray();
        var letters = chars.Where(c => char.IsLetter(c));
        var isSilence = chars.Length == 0;
        var yelledAt = letters.Any() && letters.All(c => char.IsUpper(c));
        var isQuestion = chars.Any() ? chars.Last() == '?' : false;

        return (isSilence, yelledAt, isQuestion) switch
        {
            (_, false, true) => "Sure.",
            (_, true, false) => "Whoa, chill out!",
            (_, true, true) => "Calm down, I know what I'm doing!",
            (true, _, _) => "Fine. Be that way!",
            _ => "Whatever."
        };
    }
}