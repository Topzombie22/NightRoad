using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{
    public AudioSource Screamsound;
    public GameObject Trigger;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ScreamTrigger")
        {
            Screamsound.Play();
            Trigger.SetActive(false);
        }
    }

}
