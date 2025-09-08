public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var encryptedChars = text.ToCharArray().Select(x => encryptChar(x, shiftKey)).ToArray();
        return new string(encryptedChars);
    }

    private static char encryptChar(char character, int shiftKey)
    {
        if (character < 64 || (character > 91 && character < 96) || character > 123)
            return character;

        int newcharacter = character + shiftKey;
        int mod = character > 64 && character < 91 ? 91 : 123;

        return (char) (newcharacter % mod != newcharacter ? newcharacter - 26 : newcharacter);
    }
}