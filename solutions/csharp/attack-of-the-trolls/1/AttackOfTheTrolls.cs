using System;

[Flags]
public enum AccountType : byte {
    Guest = 0b00000001,
    User = 0b00000010,
    Moderator = 0b00000100,
};

[Flags]
public enum Permission : byte {
    None = 0b00000000,
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = 0b00000111,
};

static class Permissions
{
    public static Permission Default(AccountType accountType) => accountType switch
    {
        AccountType.Guest => Permission.Read,
        AccountType.User => Permission.Read | Permission.Write,
        AccountType.Moderator => Permission.Read | Permission.Write | Permission.Delete,
        _ => Permission.None,
    };

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}
