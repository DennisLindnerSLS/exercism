using System;

public class Clock : IEquatable<Clock>
{
    private const int SecondsPerDay = 86400;
    private int _seconds; //86340 => 23:59
    
    public int Seconds
    {
        get => _seconds;
        set
        {
            _seconds = value < 0 ? ((value % SecondsPerDay) + SecondsPerDay) % SecondsPerDay : value % SecondsPerDay;
        }
    }
    public int Hours
    {
        get {
            return _seconds / 3600 % 24;
        }
    }

    public int Minutes {
        get {
            return _seconds / 60 % 60;
        }
    }

    public Clock(int hours, int minutes)
    {
        _seconds = 0;
        // Hours = Minutes = 0;
        Add(hours * 60 + minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        if (minutesToAdd < 0)
        {
            Subtract(Math.Abs(minutesToAdd));
        }
        else
        {
            Seconds += minutesToAdd * 60;
        }

        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        if (minutesToSubtract < 0)
        {
            Add(Math.Abs(minutesToSubtract));
        }
        else
        {
            Seconds -= minutesToSubtract * 60;
        }
        return this;
    }

    public bool Equals(Clock? other) => other is not null && other._seconds == _seconds;

    public override bool Equals(object? obj) => Equals(obj as Clock);

    public override int GetHashCode() => _seconds.GetHashCode();

    public static bool operator ==(Clock clock1, Clock clock2)
    {
        if (clock1 is null)
        {
            return clock2 is null;
        }

        return clock1.Equals(clock2);
    }

    public static bool operator !=(Clock clock1, Clock clock2)
    {
        if (clock1 is null)
        {
            return clock2 is not null;
        }

        return !clock1.Equals(clock2);
    }

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}
