using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return !archerIsAwake && prisonerIsAwake;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        // return (petDogIsPresent && !archerIsAwake) || (!petDogIsPresent && prisonerIsAwake && !knightIsAwake && !archerIsAwake);
        //optimizing
        /*
            (petDogIsPresent && !archerIsAwake) || (!petDogIsPresent && prisonerIsAwake && !knightIsAwake && !archerIsAwake)
            Group by common term !archerIsAwake:
            !archerIsAwake && (petDogIsPresent || (!petDogIsPresent && prisonerIsAwake && !knightIsAwake))
            Simplyfy:
            petDogIsPresent || (!petDogIsPresent && prisonerIsAwake && !knightIsAwake)
            Simplyfiy inner paratheses:
            petDogIsPresent || (prisonerIsAwake && !knightIsAwake)
            Substitute back:
            !archerIsAwake && (petDogIsPresent || (prisonerIsAwake && !knightIsAwake))
        */
        return !archerIsAwake && (petDogIsPresent || (prisonerIsAwake && !knightIsAwake));
    }
}
