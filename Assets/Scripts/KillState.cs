using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillState : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Endscrn;
    public GameObject Monster;
    public Animator anima;
    public GameObject player;
    public GameObject cam;
    public Transform lookatplay;
    public Transform head;
    private AudioSource[] allAudioSources;
    public AudioSource Jumpscare;

    private void Start()
    {
        agent = Monster.GetComponent<NavMeshAgent>();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Jumpscare.Play();
            Destroy(cam.GetComponent<MouseLook>());
            Destroy(player.GetComponent<PlayerMovement>());
            agent.isStopped = true;
            player.transform.LookAt(head);
            Monster.transform.LookAt(lookatplay);
            anima.SetBool("caught", true);
            StartCoroutine(WaitForDeath());
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(Monster.GetComponent<Chas>());
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
        Endscrn.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;

    }

}
