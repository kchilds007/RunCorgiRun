using UnityEngine;

public class Pill : TimedObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();
    }

    
}
