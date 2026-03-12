using UnityEngine;

public class Bone : TimedObject
{
    public void Start()
    {
        // replaces the time variable with the time for the BONE SPRITE
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        
        // this one allows for this class to start first
        base.Start();
    }
}
