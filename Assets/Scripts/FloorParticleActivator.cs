using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorParticleActivator : MonoBehaviour
{
    public Transform[] ParticalZones;
    public GameObject[] ParticalsActive;

    public Transform Player;

    public float deactiveDist = 75.0f;

    public float dist0;
    public float dist1;
    public float dist2;
    public float dist3;
    public float dist4;
    public float dist5;
    public float dist6;
    public float dist7;
    public float dist8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist0 = Vector3.Distance(Player.position, ParticalZones[0].position);
        dist1 = Vector3.Distance(Player.position, ParticalZones[1].position);
        dist2 = Vector3.Distance(Player.position, ParticalZones[2].position);
        dist3 = Vector3.Distance(Player.position, ParticalZones[3].position);
        dist4 = Vector3.Distance(Player.position, ParticalZones[4].position);
        dist5 = Vector3.Distance(Player.position, ParticalZones[5].position);
        dist6 = Vector3.Distance(Player.position, ParticalZones[6].position);
        dist7 = Vector3.Distance(Player.position, ParticalZones[7].position);
        dist8 = Vector3.Distance(Player.position, ParticalZones[8].position);

        if (dist0 <= deactiveDist)
        {
            ParticalsActive[0].SetActive(true);
        }
        if (dist0 > deactiveDist)
        {
            ParticalsActive[0].SetActive(false);
        }

        if (dist1 <= deactiveDist)
        {
            ParticalsActive[1].SetActive(true);
        }
        if (dist1 > deactiveDist)
        {
            ParticalsActive[1].SetActive(false);
        }

        if (dist2 <= deactiveDist)
        {
            ParticalsActive[2].SetActive(true);
        }
        if (dist2 > deactiveDist)
        {
            ParticalsActive[2].SetActive(false);
        }

        if (dist3 <= deactiveDist)
        {
            ParticalsActive[3].SetActive(true);
        }
        if (dist3 > deactiveDist)
        {
            ParticalsActive[3].SetActive(false);
        }

        if (dist4 <= deactiveDist)
        {
            ParticalsActive[4].SetActive(true);
        }
        if (dist4 > deactiveDist)
        {
            ParticalsActive[4].SetActive(false);
        }

        if (dist5 <= deactiveDist)
        {
            ParticalsActive[5].SetActive(true);
        }
        if (dist5 > deactiveDist)
        {
            ParticalsActive[5].SetActive(false);
        }

        if (dist6 <= deactiveDist)
        {
            ParticalsActive[6].SetActive(true);
        }
        if (dist6 > deactiveDist)
        {
            ParticalsActive[6].SetActive(false);
        }

        if (dist7 <= deactiveDist)
        {
            ParticalsActive[7].SetActive(true);
        }
        if (dist7 > deactiveDist)
        {
            ParticalsActive[7].SetActive(false);
        }

        if (dist8 <= deactiveDist)
        {
            ParticalsActive[8].SetActive(true);
        }
        if (dist8 > deactiveDist)
        {
            ParticalsActive[8].SetActive(false);
        }
    }
}
