using UnityEngine;

public class PillPlacer : TimedObjectPlacer
{
    public void Start()
    {    
        minSecondsToWait = GameParameters.PillMinSecondsToWait;
        maxSecondsToWait = GameParameters.PillMaxSecondsToWait;
    }
}
