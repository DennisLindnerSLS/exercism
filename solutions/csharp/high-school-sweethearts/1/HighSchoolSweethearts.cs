using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        string content = studentA.Trim() + " ♡ " + studentB.Trim();
        int pad = (61 - content.Length)/2;
        int extraPad = (61 - content.Length) % 2;
        return $"{new string(' ', pad-1)}{studentA + " ♡ " + studentB}{new string(' ', pad + extraPad + 1)}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        int maxLength = 25;
        string content = studentA.Trim() + "  +  " + studentB.Trim();
        int pad = (maxLength - content.Length)/2;
        string result =
    $@"******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{centerString(pad, content)}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
        return result;
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        return $"{studentA} and {studentB} have been dating since {start.ToString("dd.MM.yyyy")} - that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
    }

    private static string centerString(int pad, string content){
        return $"{new string(' ', pad)}{content}{new string(' ', pad)}";
    }
}
