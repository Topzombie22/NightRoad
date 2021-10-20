using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireFlicker : MonoBehaviour
{
    Light campfire;

    // Start is called before the first frame update
    void Start()
    {
        campfire = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        campfire.intensity = Random.Range(5, 10);
    }
}
