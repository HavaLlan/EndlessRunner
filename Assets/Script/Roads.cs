using UnityEngine;

public class Roads : MonoBehaviour
{
    private road1 Road1;

    void Start()
    {
        Road1 = GameObject.Find("road1").GetComponent<road1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Road1.RoadSpawn();
            Road1.destroyCount++;
            if (Road1.destroyCount > 3)
            {
                Road1.DestroyRoad();
            }
        }

    }
}
