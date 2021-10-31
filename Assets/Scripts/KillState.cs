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
    public Transform head;

    private void Start()
    {
        agent = Monster.GetComponent<NavMeshAgent>();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            agent.isStopped = true;
            player.transform.LookAt(head, Vector3.up);
            Destroy(player.GetComponent<PlayerMovement>());
            anima.SetBool("caught", true);
            StartCoroutine(WaitForDeath());
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.75f);
        Endscrn.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;

    }

}
