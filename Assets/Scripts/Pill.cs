using UnityEngine;

public class Pill : TimedObject
{
    public void Start()
    {
        // replaces the time variable with the time for the PILL SPRITE
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        
        // this one allows for this class to start first
        base.Start();
    }
}
