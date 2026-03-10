using System.Collections;
using UnityEngine;

// INHERITS from the 'TimedObject' class,
// which inherits from MonoBehaviorScript
public class Beer : TimedObject
{
    public void Start()
    {
        // replaces the time variable with the time for the BEER SPRITE
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        
        // this one allows for this class to start first
        base.Start();
    }
}
