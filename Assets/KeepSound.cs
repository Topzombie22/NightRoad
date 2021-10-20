using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSound : MonoBehaviour
{
    public AudioSource audiosource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audiosource = GetComponent<AudioSource>();
    }
}
