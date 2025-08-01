class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven(){
        return 40;
    }
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minInOven){
        return ExpectedMinutesInOven() - minInOven;
    }
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int nmbrOfLayers){
        return nmbrOfLayers << 1;
    }
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int nmbrOfLayers, int minInOven){
        return PreparationTimeInMinutes(nmbrOfLayers) + minInOven;
    }
}
