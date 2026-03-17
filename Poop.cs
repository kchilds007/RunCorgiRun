public class Poop : TimedObject
{
    public void Start()//calls child start class and not parent
    {
        secondsOnScreen = GameParameters.PoopSecondsOnScreen;
        base.Start();// calls the parent start
    }
}
