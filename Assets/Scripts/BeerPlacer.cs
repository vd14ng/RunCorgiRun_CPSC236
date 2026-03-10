using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject BeerPrefab;
    void Update()
    {
        StartCoroutine(CountdownUntilCreation());
    }

    // waits before spawning in another BEER SPRITE
    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(3f);
        Place();
    }

    // places a BEER SPRITE at a random location
    private void Place()
    {
        Instantiate(BeerPrefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity); 
    }
}
