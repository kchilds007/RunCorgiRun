using UnityEngine;
using System.Collections;

public class BeerPlacer : TimedObjectPlacer
{
	public void Start()
	{    
		minSecondsToWait = GameParameters.BeerMinSecondsToWait;
		maxSecondsToWait = GameParameters.BeerMaxSecondsToWait;
	}
}
