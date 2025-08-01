using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool isNewYork = false;
        bool isFake = false;
        string localNumber = "";

        if(phoneNumber.StartsWith("212"))
            isNewYork = true;

        if(phoneNumber.IndexOf("555") == 4)
            isFake = true;

        localNumber = phoneNumber.Substring(8);
        return (isNewYork, isFake, localNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
