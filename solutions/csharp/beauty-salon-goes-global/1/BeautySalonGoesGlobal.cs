using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var tzi = GetTimeZoneInfo(location);
        var parsedDate = DateTime.Parse(appointmentDateDescription);
        return TimeZoneInfo.ConvertTime(parsedDate, tzi, TimeZoneInfo.Utc);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        if(alertLevel == AlertLevel.Early){
            appointment = appointment.AddDays(-1);
        }else if(alertLevel == AlertLevel.Standard){
            appointment = appointment.AddHours(-1);
            appointment = appointment.AddMinutes(-45);
        }else if(alertLevel == AlertLevel.Late){
            appointment = appointment.AddMinutes(-30);
        }
        return appointment;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var tzi = GetTimeZoneInfo(location);
        bool isDaylightSavingTime = tzi.IsDaylightSavingTime(dt);
        
        for(int i = 1; i < 8; i++){
            var date = dt.AddDays(-i);
            if(tzi.IsDaylightSavingTime(date) != isDaylightSavingTime)
                return true;
        }

        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        if(DateTime.TryParse(dtStr, GetCultureInfo(location), out var date)){
            return date;
        }
        return new DateTime(1,1,1);
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location){
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)){
            return GetTimeZoneInfoWindows(location);
        }else{
            return GetTimeZoneInfoOSX(location);
        }
    }

    private static TimeZoneInfo GetTimeZoneInfoWindows(Location location) => location switch {
        Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
        Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
        Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
    };

    private static TimeZoneInfo GetTimeZoneInfoOSX(Location location) => location switch {
        Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
        Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
        Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
    };

    private static CultureInfo GetCultureInfo(Location location) => location switch {
        Location.NewYork => new CultureInfo("en-US"),
        Location.London => new CultureInfo("en-GB"),
        Location.Paris => new CultureInfo("fr-FR"),
    };
}
