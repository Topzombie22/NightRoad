using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScrn : MonoBehaviour
{
    public GameObject Endscrn;
    public GameObject gameoover;
    public GameObject retry;
    public GameObject menu;

    public void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Endscrn.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}