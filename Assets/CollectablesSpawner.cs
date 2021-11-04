using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    public GameObject[] Wrench;
    public GameObject[] Gear;
    public GameObject[] ScrewDriver;
    public int SpawnLocation;
    public int NoRepetition;
    public int NoRepetition2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLocation = Random.Range(0, 5);
        Wrench[SpawnLocation].SetActive(true);
        SpawnLocation = NoRepetition;
        while (SpawnLocation == NoRepetition)
        {
            SpawnLocation = Random.Range(0, 5);
        }
        Debug.Log("Finished");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
