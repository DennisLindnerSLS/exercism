using System;

class RemoteControlCar
{
    private uint odometer = 0;
    private byte battery = 100;
    
    public static RemoteControlCar Buy()
    {
        return new();
    }

    public string DistanceDisplay()
    {
        return $"Driven {odometer} meters";
    }

    public string BatteryDisplay()
    {
        return battery <= 0 ? "Battery empty" : $"Battery at {battery}%";
    }

    public void Drive()
    {
        if(battery > 0){
            odometer += 20;
            battery -= 1;
        }
    }
}
