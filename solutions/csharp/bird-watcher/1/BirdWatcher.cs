using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new[]{0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay.TakeLast(1).FirstOrDefault();
    }

    public void IncrementTodaysCount()
    {
        if(birdsPerDay.Length <= 0)
            return;
        
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay.Where(x => x == 0).Count() > 0;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        numberOfDays = numberOfDays > birdsPerDay.Length ? birdsPerDay.Length : numberOfDays;
        var count = 0;
        for(int i = 0; i < numberOfDays; i++){
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        return birdsPerDay.Where(x => x >= 5).Count();
    }
}
