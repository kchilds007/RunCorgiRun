using UnityEngine;
using System.Collections;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    public float minSecondsToWait;
    public float maxSecondsToWait;
    
    private bool isOkToCreate = true;
    // Update is called once per frame
    void Update()
    {
        if(isOkToCreate)
        {
            StartCoroutine(CountDownUntilCreation());
        }
    }


    IEnumerator CountDownUntilCreation()
    {
        isOkToCreate = false;

        float secondsToWait = Random.Range(minSecondsToWait, maxSecondsToWait);
		
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOkToCreate = true;
    }

    private void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
