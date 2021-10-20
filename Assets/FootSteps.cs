using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public Rigidbody rb;
    public float speeddisp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = rb.velocity.magnitude;
        speeddisp = speed;
    }
}
