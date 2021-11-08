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
        needText.GetComponent<Text>().CrossFadeAlpha(0, 0.0f, true);
        placeText.GetComponent<Text>().CrossFadeAlpha(0, 0.0f, true);
        alreadyHaveText.GetComponent<Text>().CrossFadeAlpha(0, 0.0f, true);
    }

    void OnTriggerStay(Collider other)
    {
        if (Pickuplearned == false && other.gameObject.tag == "Collectables")
        {
            StartCoroutine(FadePickUpLeanred());
            Pickuplearned = true;
        }

        if (other.gameObject.tag == "Collectables" && Collectables < 1 && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(FadeLeadToTruck());
            Debug.Log("Step 2");
            Destroy(other.gameObject);
            Collectables = Collectables + 1;
            pickNoise.Play();
            StartCoroutine(WaitedTooMany());
        }

        if (other.gameObject.tag == "Collectables" && Collectables >= 1 && hasWaited == true)
        {
            StartCoroutine(FadeTooManyItems());
            hasWaited = false;
        }

        if (other.gameObject.tag == "Truck" && Collectables == 1 && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(FadeLeadToShacks());
            Collectables = Collectables - 1;
            TruckProgress = TruckProgress + 1;
            hasWaited = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectables" || Input.GetKey(KeyCode.E))
        {
            pickText.GetComponent<Text>().CrossFadeAlpha(0, 2.0f, true);
        }
    }

    void Update()
    {

    }

    IEnumerator FadeLeadToTruck() 
    {
        yield return new WaitForSeconds(6);
        needText.GetComponent<Text>().CrossFadeAlpha(1, 4.0f, true);
        yield return new WaitForSeconds(4.5f);
        needText.GetComponent<Text>().CrossFadeAlpha(0, 4.0f, true);
    }

    IEnumerator FadeLeadToShacks()
    {
        yield return new WaitForSeconds(2);
        placeText.GetComponent<Text>().CrossFadeAlpha(1, 4.0f, true);
        yield return new WaitForSeconds(4.5f);
        placeText.GetComponent<Text>().CrossFadeAlpha(0, 4.0f, true);
    }

    IEnumerator FadePickUpLeanred()
    {
        pickText.GetComponent<Text>().CrossFadeAlpha(1, 4.0f, true);
        yield return new WaitForSeconds(4.5f);
        pickText.GetComponent<Text>().CrossFadeAlpha(0, 4.0f, true);
    }

    IEnumerator FadeTooManyItems()
    {
        alreadyHaveText.GetComponent<Text>().CrossFadeAlpha(1, 4.0f, true);
        yield return new WaitForSeconds(4.5f);
        alreadyHaveText.GetComponent<Text>().CrossFadeAlpha(0, 4.0f, true);
        hasWaited = true;
    }

    IEnumerator WaitedTooMany()
    {
        yield return new WaitForSeconds(6);
        hasWaited = true;
    }
}