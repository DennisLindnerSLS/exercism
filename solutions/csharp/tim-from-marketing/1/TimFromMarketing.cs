using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var userId = id == null ? "" : $"[{id}] - ";
        var deparment = department == null ? " - OWNER" : $" - {department.ToUpper()}";
        return $"{userId}{name}{deparment}";
    }
}
