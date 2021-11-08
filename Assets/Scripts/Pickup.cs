using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool Pickuplearned;

    private void Start()
    {
        pickText.GetComponent<Text>().CrossFadeAlpha(0, 0.0f, true);
    }

    void OnTriggerStay(Collider other)
    {
        if (Pickuplearned == false)
        {
            pickText.GetComponent<Text>().CrossFadeAlpha(1, 4.0f, true);
            if (Pickuplearned == true)
            {
                pickText.GetComponent<Text>().CrossFadeAlpha(0, 2.0f, true);
            }

        }

        if (other.gameObject.tag == "Collectables" && Collectables < 1 && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Step 2");
            Destroy(other.gameObject);
            Collectables = Collectables + 1;
            pickNoise.Play();
        }

        if (other.gameObject.tag == "Truck" && Collectables < 1)
        {
            Collectables = Collectables - 1;
            TruckProgress = TruckProgress + 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        pickText.GetComponent<Text>().CrossFadeAlpha(0, 1.0f, true);
    }

    void Update()
    {

    }

    IEnumerator Timer() 
    {

        yield return new WaitForSeconds(5);
        hasWaited = true;

    }

    IEnumerator LeaningTimer()
    {
        yield return new WaitForSeconds(4);
        Pickuplearned = true;
    }

}