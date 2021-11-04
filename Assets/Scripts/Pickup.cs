using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject Trigger;
    public int Collectables;
    public int TruckProgress;
    public AudioSource pickNoise;
    public GameObject pickText;
    public GameObject placeText;
    public GameObject alreadyHaveText;
    public GameObject needText;
    public GameObject winGate;
    public bool hasWaited;
    public bool LookingAt;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Collectables" && Collectables < 1)
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

        if (other.gameObject.tag == "Truck" && Collectables < 1)
        {
            Collectables = Collectables - 1;
            TruckProgress = TruckProgress + 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        pickText.SetActive(false);
    }

    void Update()
    {
        
    }

    IEnumerator Timer() 
    {

        yield return new WaitForSeconds(5);
        hasWaited = true;

    }

}