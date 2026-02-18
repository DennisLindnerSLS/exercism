using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? other){
        return other != null 
            && other.GetType() == this.GetType()
            && this.EyeColor == (other as FacialFeatures).EyeColor
            && this.PhiltrumWidth == (other as FacialFeatures).PhiltrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override int GetHashCode()
    {
        return EyeColor.GetHashCode() 
            ^ PhiltrumWidth.GetHashCode();
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? other){
        return other != null 
            && other.GetType() == this.GetType()
            && this.Email == (other as Identity).Email
            && this.FacialFeatures.Equals((other as Identity).FacialFeatures);
    }
    // TODO: implement equality and GetHashCode() methods
    public override int GetHashCode()
    {
        return Email.GetHashCode() 
            ^ FacialFeatures.GetHashCode();
    }
}

public class Authenticator
{
    private HashSet<Identity> identities = new();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));
    }

    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
}
