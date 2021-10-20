using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool IsGrounded;
    public float distToGround = 1f;
    public float gravity = -9.81f;


    public void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    void Update()
    {
        if (IsGrounded == false)
        {
            new Vector3(0, gravity * Time.deltaTime, 0);
        }
        else
        {
            new Vector3(0, 0, 0);
        }
    }









}
