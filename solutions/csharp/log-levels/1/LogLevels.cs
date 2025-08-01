using System;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        string pattern = @"^\[(?:INFO|WARNING|ERROR)\]:";
        if(Regex.IsMatch(logLine, pattern)){
            logLine = Regex.Replace(logLine, pattern, String.Empty);
        }

        return logLine.Trim();
    }

    public static string LogLevel(string logLine)
    {
        string pattern = @"^\[(?:INFO|WARNING|ERROR)\]:";
        if(Regex.IsMatch(logLine, pattern)){
            var matches = Regex.Matches(logLine, pattern);
            if(matches.Count > 0){
                return matches[0]
                    .Value
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace(":", "")
                    .Trim()
                    .ToLower();
            }
        }
        return "";
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
