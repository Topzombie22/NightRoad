using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject Trigger;
    public int Collectables;
    public AudioSource pickNoise;
    public GameObject pickText;
    public GameObject winGate;
    public bool hasWaited;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Collectables")
        {
            pickText.SetActive(true);
            Debug.Log("Step 2");
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
                Collectables = Collectables + 1;
                pickNoise.Play();
                pickText.SetActive(false);

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        pickText.SetActive(false);
    }

    void Update()
    {
        if (Collectables == 3 && hasWaited == false)

        {
            Timer();
            winGate.SetActive(true);
        }
        else
        {
            Timer();
        }
    }

    IEnumerator Timer() 
    {

        yield return new WaitForSeconds(5);
        hasWaited = true;

    }

}