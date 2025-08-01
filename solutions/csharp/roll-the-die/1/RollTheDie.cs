using System;

public class Player
{
    public int RollDie()
    {
        var rnd = new Random();
        return rnd.Next(1,18);
    }

    public double GenerateSpellStrength()
    {
        var rand = new Random();
        return rand.NextDouble() * 100;
    }
}
