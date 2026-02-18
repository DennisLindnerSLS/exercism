using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class LogParser
{
    public bool IsValidLine(string text) => text switch
    {
        _ when text.StartsWith("[TRC]") 
            || text.StartsWith("[DBG]") 
            || text.StartsWith("[INF]") 
            || text.StartsWith("[WRN]") 
            || text.StartsWith("[ERR]") 
            || text.StartsWith("[FTL]") => true,
        _ => false
    };

    public string[] SplitLogLine(string text) 
        => Regex.Split(text, @"(?:<[^\w<>]*[\^*= -]+[^\w<>]*>)");

    public int CountQuotedPasswords(string lines) 
        => Regex.Count(lines, "(\".*(password).*\")", RegexOptions.IgnoreCase);

    public string RemoveEndOfLineText(string line) 
        => Regex.Replace(line, "(end-of-line\\d*)", "");

    public string[] ListLinesWithPasswords(string[] lines){
        List<string> result = new();
        foreach(var l in lines){
            var pwMatch = Regex.Match(
                l, 
                "\\bpassword\\b", 
                RegexOptions.IgnoreCase
            );
            var pwSecretMatch = Regex.Match(
                l, 
                "(\\w+password\\w+|\\w*password\\w+|\\w+password\\w*)", 
                RegexOptions.IgnoreCase
            );
            if(pwSecretMatch.Success)
                result.Add($"{pwSecretMatch.Value}: {l}");
            else if(pwMatch.Success)
                result.Add($"--------: {l}");
            else 
                result.Add(l);
        }

        return result.ToArray();
    } 
}
