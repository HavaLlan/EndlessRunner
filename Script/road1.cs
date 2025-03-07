using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road1 : MonoBehaviour
{
    public GameObject[] segment;
    [SerializeField] float zPos;
    [SerializeField] int segmentNum;
    [SerializeField] GameObject startRoad;
    [SerializeField] Renderer oldRoadRender;
    [SerializeField] Renderer oldRoadRender2;

    private Queue<Renderer> roadsQueue = new Queue<Renderer>();

    public int destroyCount = 0;

    private void Start()
    {
        zPos = startRoad.transform.position.z;

        oldRoadRender2 = startRoad.GetComponent<Renderer>();
        // Baþlangýç yolu oluþturma
        for (int i = 0; i < segment.Length; i++) 
        {
            RoadSpawn();
        }
    }

    public void RoadSpawn()
    {
        segmentNum = Random.Range(0, segment.Length);
        GameObject newRoad = Instantiate(segment[segmentNum], transform);
        oldRoadRender = newRoad.GetComponent<Renderer>();
        roadsQueue.Enqueue(oldRoadRender);
        zPos += ((oldRoadRender.bounds.size.z / 2) + (oldRoadRender2.bounds.size.z / 2));
        newRoad.transform.position = new Vector3(0, 0, zPos);
        oldRoadRender2 = oldRoadRender;
    }

    public void DestroyRoad()
    {
        Renderer oldRoad = roadsQueue.Dequeue();
        Destroy(oldRoad.gameObject);
    }
}
