using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public GameObject PoopPrefab;
    
    public void Place(Vector3 corgiPosition)
    {
        // instantiate (only works with prefab)
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
    }
}
