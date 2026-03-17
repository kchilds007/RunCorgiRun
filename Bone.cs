using UnityEngine;

public class Bone : TimedObject
{
    void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }
}
