using System;

class RemoteControlCar
{
    private uint _odometer = 0;
    private byte _battery = 100;
    
    public static RemoteControlCar Buy()
    {
        return new();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_odometer} meters";
    }

    public string BatteryDisplay()
    {
        return _battery <= 0 ? "Battery empty" : $"Battery at {_battery}%";
    }

    public void Drive()
    {
        if(_battery > 0){
            _odometer += 20;
            _battery -= 1;
        }
    }
}
