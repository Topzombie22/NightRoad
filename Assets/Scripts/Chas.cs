using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chas : MonoBehaviour
{

    public AudioSource MonsterScream;
    public AudioSource MonsterRunning;

    public Transform[] patrolPoints;
    public int destPoint = 0;

    public bool alerted;

    Transform target;
    NavMeshAgent agent;
    public float speed = 1.0f;
    public int chases = 0;
    public int cycle = 3;
    public bool chasingPlayer;
    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        GotoNextPoint();
    }

    void Update()
    {
        if (agent.speed >= 0.01f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving == true)
        {
            MonsterRunning.Play();
        }
        else
        {
            MonsterRunning.Stop();
        }


        
        if (chasingPlayer == true)
        {
            agent.SetDestination(target.position);
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sound" && alerted == false)
        {
            StartCoroutine(WaitingSound());
            Debug.Log("help2");
        }

        if (other.gameObject.tag == "Player" && alerted == false)
        {

            agent.speed = 0.0f;
            agent.SetDestination(target.position);
            MonsterScream.Play();
            StartCoroutine(Timer());
            alerted = true;
            StartCoroutine(Chasing());
        }
    }

    void GotoNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % patrolPoints.Length;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        chasingPlayer = true;
        agent.speed = 6.0f;
    }

    IEnumerator Chasing()
    {
        yield return new WaitForSeconds(10);
        chasingPlayer = false;
        alerted = false;
    }

    IEnumerator WaitingSound()
    {
        agent.speed = 0.0f;
        yield return new WaitForSeconds(2);
        agent.SetDestination(target.position);
        agent.speed = 6.0f;
        yield return new WaitForSeconds(2);
        agent.speed = 0.0f;
    }

    IEnumerator SpeedReset()
    {
        yield return new WaitForSeconds(2);
        agent.speed = 0.0f;
    }
}
