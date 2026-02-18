using System.Diagnostics.CodeAnalysis;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (!(obj is Coord other))
            return false;

        return this.X == other.X && this.Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public double DistanceTo(Coord target)
    {
        double dx = X - target.X;
        double dy = Y - target.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

public struct Plot
{
    public Coord[] coordinates;

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        coordinates = [coord1, coord2, coord3, coord4];
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (!(obj is Plot other))
            return false;
        return coordinates
            .All(coords => other.coordinates.Contains(coords))
            && other.coordinates.Length == this.coordinates.Length;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(coordinates);
    }

    public double GetLongestSide()
    {
        var coords = coordinates;
        return coords
            .Select((coord, i) => coord.DistanceTo(coords[(i + 1) % coords.Length]))
            .Max();
    }
}


public class ClaimsHandler
{
    private List<Plot> plots = new();
    public void StakeClaim(Plot plot)
    {
        plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return plots.Last().Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        return plots.MaxBy(plot => plot.GetLongestSide());
    }
}
