using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    // initalizing the time variable, which will
    // be changed depending on the class
    public float secondsOnScreen = 1f;
    public void Start()
    {
        StartCoroutine(CountdownUntilDeath());
    }
    IEnumerator CountdownUntilDeath()
    {
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(gameObject);
    }
}
