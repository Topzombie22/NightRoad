using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTracker : MonoBehaviour
{

    public Transform player;
    public Transform playerMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot = new Vector3(0, 0, -player.transform.eulerAngles.y + 90);
        playerMap.transform.rotation = Quaternion.Euler(newRot);

        Vector3 newPos = new Vector3(-player.transform.position.z /2 + 1240.5f, player.transform.position.x /2 + 573.3f, 0);
        playerMap.transform.position = newPos;
    }
}
