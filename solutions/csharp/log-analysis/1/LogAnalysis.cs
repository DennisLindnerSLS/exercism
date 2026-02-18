using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string substring){
        var idx = str.IndexOf(substring) + substring.Length;
        return str.Substring(idx);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string start, string end){
        var startIdx = str.IndexOf(start) + start.Length;
        var endIdx = str.IndexOf(end);
        return str.Substring(startIdx, endIdx - startIdx);
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str){
        return str.SubstringAfter("]:").Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str){
        return str.SubstringBetween("[", "]");
    }
}