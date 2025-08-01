using System;

class RemoteControlCar
{
    private int _speed = 0;
    private int _batteryDrain = 0;
    private int _battery = 100;
    private int _odometer = 0;
    
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain){
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _battery < _batteryDrain || _battery <= 0;
    }

    public int DistanceDriven()
    {
        return _odometer;
    }

    public void Drive()
    {
        if(_battery < _batteryDrain)
            return;

        _odometer += _speed;
        _battery -= _batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new(50, 4);
    }
}

class RaceTrack
{
    private int _distance = 0;
    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance){
        _distance = distance;
    }
    
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained() && car.DistanceDriven() < _distance){
            car.Drive();
        }
        return car.DistanceDriven() >= _distance;
    }
}
