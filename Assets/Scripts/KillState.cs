using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class KillState : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject gameovr;
    public GameObject mainmenuBut;
    public GameObject restartBut;
    public GameObject Endscrn;
    public GameObject Monster;
    public Animator anima;
    public GameObject Map;
    public GameObject wintext;
    public GameObject player;
    public GameObject cam;
    public Transform lookatplay;
    public Transform head;
    private AudioSource[] allAudioSources;
    public AudioSource Jumpscare;
    public AudioSource deathSong;
    public bool isdead;
    public bool hasresetcolor;
    public bool isfaded;

    private void Start()
    {
        agent = Monster.GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if (isfaded == true)
        {
            gameovr.GetComponent<RawImage>().color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1.5f));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Monster.GetComponent<Chas>().isKilled = true;
            agent.speed = 0.0f;
            isdead = true;
            Jumpscare.Play();
            Destroy(cam.GetComponent<MouseLook>());
            Destroy(player.GetComponent<PlayerMovement>());
            agent.isStopped = true;
            player.transform.LookAt(head);
            Monster.transform.LookAt(lookatplay);
            anima.SetBool("caught", true);
            StartCoroutine(WaitForDeath());
            wintext.SetActive(false);
            Map.SetActive(false);
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
        mainmenuBut.GetComponent<RawImage>().CrossFadeAlpha(0, 0.0f, true);
        restartBut.GetComponent<RawImage>().CrossFadeAlpha(0, 0.0f, true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        gameovr.GetComponent<RawImage>().CrossFadeAlpha(0, 0.0f, true);
        gameovr.GetComponent<RawImage>().CrossFadeAlpha(1, 2.75f, false);
        yield return new WaitForSeconds(3.25f);
        deathSong.Play();
        isfaded = true;
        yield return new WaitForSeconds(0.5f);
        mainmenuBut.GetComponent<RawImage>().CrossFadeAlpha(1, 3.0f, false);
        restartBut.GetComponent<RawImage>().CrossFadeAlpha(1, 3.0f, false);
        Cursor.lockState = CursorLockMode.None;


    }

}
