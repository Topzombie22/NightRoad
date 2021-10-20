using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public Transform target;
    public int cameraSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Vector3.zero);
        transform.Translate(1 * Time.deltaTime, 0, 0);
    }
}
