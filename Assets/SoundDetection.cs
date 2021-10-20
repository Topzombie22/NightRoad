using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour
{

    public GameObject player;
    public GameObject soundDetection;
    public GameObject spawnPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPos = spawnPosition.transform.position;
        Vector3 lastPosition = player.transform.position;

     if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SoundDetec();
        }   
    }

    void SoundDetec()
    {
        StartCoroutine(Timer());    
    }

    IEnumerator Timer()
    {
        Vector3 spawnPos = spawnPosition.transform.position;
        Vector3 lastPosition = player.transform.position;
        soundDetection.transform.position = lastPosition;
        yield return new WaitForSeconds(1);
        soundDetection.transform.position = spawnPos;
        Debug.Log("Help");
    }
}
