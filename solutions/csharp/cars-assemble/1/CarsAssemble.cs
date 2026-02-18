using System;

static class AssemblyLine
{
    private const double _carsPerHour = 221.0;
    
    public static double SuccessRate(int speed)
    {
        return speed == 0 ? 0 : speed >= 1 && speed <= 4 ? 1.0 : speed >= 5 && speed <= 8 ? .9 : speed == 9 ? .8 : .77;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return _carsPerHour * (double)speed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(_carsPerHour * (double)speed * SuccessRate(speed) / 60.0);
    }
}
