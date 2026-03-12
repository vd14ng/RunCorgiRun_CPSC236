using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;

    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    private bool isOkToCreate = true;
    void Update()
    {
        if (isOkToCreate)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }
    
    // waits before spawning in another BEER SPRITE
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        
        yield return new WaitForSeconds(secondsToWait);
        Place();

        isOkToCreate = true;
    }

    // places a BEER SPRITE at a random location
    private void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity); 
    }
}
