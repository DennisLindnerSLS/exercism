public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var encryptedChars = text.ToCharArray().Select(x => encryptChar(x, shiftKey)).ToArray();
        return new string(encryptedChars);
    }

    private static char encryptChar(char character, int shiftKey)
    {
        int newcharacter = character + shiftKey;
        if (character > 64 && character < 91)
        {
            newcharacter = newcharacter % 91 != newcharacter ? newcharacter - 26 : newcharacter;
        }
        else if (character > 96 && character < 123)
        {
            newcharacter = newcharacter % 123 != newcharacter ? newcharacter - 26 : newcharacter;
        }
        else
        {
            return character;
        }

        return (char) newcharacter;
    }
}