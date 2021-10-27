using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillState : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Endscrn;
    public GameObject Monster;
    public Animation Death;
    public Camera cam;
    public GameObject player;
    public Transform head;

    private void Start()
    {
        agent = Monster.GetComponent<NavMeshAgent>();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            agent.speed = 0.0f;
            Destroy(Monster.GetComponent<NavMeshAgent>());
            Destroy(player.GetComponent<PlayerMovement>());
            cam.transform.LookAt(head);
            Death.Play("Kill Animation");
            StartCoroutine(WaitForDeath());
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.75f);
        Endscrn.SetActive(true);
        Time.timeScale = 0;
        
    }

}
