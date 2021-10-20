using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneWalk : MonoBehaviour
{
    public Animation phoneWalk;

    // Start is called before the first frame update
    void Start()
    {
        phoneWalk = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if ( x == 0 && z == 0)
        {
        
        }
        else
        {
            phoneWalk.Play();
        }

    }
}
