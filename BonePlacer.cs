using UnityEngine;

public class BonePlacer : TimedObjectPlacer
{
    public void Start()
    {    
        minSecondsToWait = GameParameters.BoneMinSecondsToWait;
        maxSecondsToWait = GameParameters.BoneMaxSecondsToWait;
    }
}
