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
        NoRepetition = SpawnLocation;
        while (SpawnLocation == NoRepetition)
        {
            SpawnLocation = Random.Range(0, 5);
        }
        NoRepetition2 = SpawnLocation;
        Gear[SpawnLocation].SetActive(true);
        while (SpawnLocation == NoRepetition2)
        {
            SpawnLocation = Random.Range(0, 5);
            Debug.Log("Rolled");
            while (SpawnLocation == NoRepetition)
            {
                SpawnLocation = Random.Range(0, 5);
                Debug.Log("Rolledx2"); 
            }
        }
        ScrewDriver[SpawnLocation].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
