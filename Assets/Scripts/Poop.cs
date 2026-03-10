using System.Collections;
using UnityEngine;

// INHERITS from the 'TimedObject' class,
// which inherits from MonoBehaviorScript
public class Poop : TimedObject
{
    public void Start()
    {
        // replaces the time variable with the time for the POOP SPRITE
        secondsOnScreen = GameParameters.PoopSecondsOnScreen;
        
        // this one allows for this class to start first
        base.Start();
    }
}
