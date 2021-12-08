using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTracker : MonoBehaviour
{

    public Transform player;
    public Transform playerMap;
    public Transform playerMMap;

    private Transform recttrans;

    // Start is called before the first frame update
    void Start()
    {
        recttrans = playerMap.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot = new Vector3(0, 0, -player.transform.eulerAngles.y + 90);
        playerMap.transform.rotation = Quaternion.Euler(newRot);
        Vector2 newPos = new Vector2(-player.transform.position.z / 2f, player.transform.position.x / 2.5f);
        playerMap.GetComponent<RectTransform>().anchoredPosition = newPos;
        
    }
}
