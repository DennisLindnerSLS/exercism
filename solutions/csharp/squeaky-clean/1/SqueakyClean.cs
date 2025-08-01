using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        return identifier
            .Replace(" ", "_")
            .Replace("\0", "CTRL")
            .ToKebab()
            .RemoveGreekLetters()
            .RemoveNonLetters();
    }

    private static string RemoveGreekLetters(this string str){
        StringBuilder sb = new();
        foreach(var c in str){
            if(c >= 945 && c <= 969)
                continue;
            sb.Append(c);
        }

        return sb.ToString();
    }

    private static string RemoveNonLetters(this string str){
        StringBuilder sb = new();
        foreach(var c in str){
            if(c == '_' || Char.IsLetter(c)){
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static string ToKebab(this string str){
        StringBuilder sb = new();
        bool dashFlag = false;
        foreach(char c in str){     
            if(c == '-'){
                dashFlag = true;
                continue;
            }

            if(dashFlag){
                sb.Append(Char.ToUpper(c));
                dashFlag = false;
            }
            else
                sb.Append(c);
        }

        return sb.ToString();
    }
}
