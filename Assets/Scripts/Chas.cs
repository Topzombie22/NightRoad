using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chas : MonoBehaviour
{

    public AudioSource MonsterScream;
    public AudioSource MonsterRunning;
    public Animator anima;

    public Transform PatrolAreaOne;
    public Transform PatrolAreaTwo;
    public Transform PatrolAreaThree;

    public bool WaitingForPatrol = false;
    public int PatrolZone;
    public int PatrolWaitTime;

    public float distPatrolOne;
    public float distPatrolTwo;
    public float distPatrolThree;

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

        }
        else
        {

        }


        if (chasingPlayer == true)
        {
            agent.SetDestination(target.position);
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void FixedUpdate()
    {
        distPatrolOne = Vector3.Distance(target.position, PatrolAreaOne.position);
        distPatrolTwo = Vector3.Distance(target.position, PatrolAreaTwo.position);
        distPatrolThree = Vector3.Distance(target.position, PatrolAreaThree.position);

        if (distPatrolOne < distPatrolTwo && distPatrolOne < distPatrolThree)
        {
            PatrolZone = 1;
        }
        if (distPatrolTwo < distPatrolOne && distPatrolTwo < distPatrolThree)
        {
            PatrolZone = 2;
        }
        if (distPatrolThree < distPatrolOne && distPatrolThree < distPatrolTwo)
        {
            PatrolZone = 3;
        }
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

            agent.isStopped = true;
            agent.SetDestination(target.position);
            MonsterScream.Play();
            StartCoroutine(Timer());
            alerted = true;
            StartCoroutine(Chasing());
        }
    }

    void GotoNextPoint()
    {
        if (PatrolZone == 1)
        {
            agent.destination = patrolPoints[destPoint].position;

            if (agent.remainingDistance < 0.5f)
            {
                WaitingForPatrol = true;
            }

            if (WaitingForPatrol == true)
            {
                StartCoroutine(WaitForPatrol());
                WaitingForPatrol = false;
            }

            destPoint = destPoint + 1;

            if (destPoint >= 4)
            {
                destPoint = 0;
            }
        }

        if (PatrolZone == 2)
        {
            agent.destination = patrolPoints[destPoint].position;

            if (agent.remainingDistance < 0.5f)
            {
                WaitingForPatrol = true;
            }

            if (WaitingForPatrol == true)
            {
                StartCoroutine(WaitForPatrol());
                WaitingForPatrol = false;
            }

            destPoint = destPoint + 1;

            if (destPoint <= 4)
            {
                destPoint = 4;
            }

            if (destPoint >= 7)
            {
                destPoint = 4;
            }
        }
        if (PatrolZone == 3)
        {
            agent.destination = patrolPoints[destPoint].position;

            if (agent.remainingDistance < 0.5f)
            {
                WaitingForPatrol = true;
            }

            if (WaitingForPatrol == true)
            {
                StartCoroutine(WaitForPatrol());
                WaitingForPatrol = false;
            }

            destPoint = destPoint + 1;

            if (destPoint <= 8)
            {
                destPoint = 8;
            }

            if (destPoint >= 12)
            {
                destPoint = 8;
            }
        }
    }
            IEnumerator Timer()
            {
            yield return new WaitForSeconds(4);
            anima.SetBool("alerted", true);
            agent.isStopped = false;
            MonsterRunning.Play();
            chasingPlayer = true;
            yield return new WaitForSeconds(2);
            agent.speed = 10.0f;
    }

        IEnumerator Chasing()
        {
            yield return new WaitForSeconds(10);
            chasingPlayer = false;
            alerted = false;
            MonsterRunning.Stop();
            anima.SetBool("alerted", false);
    }

        IEnumerator WaitingSound()
        {
            agent.isStopped = true;
            yield return new WaitForSeconds(2);
            agent.SetDestination(target.position);
            agent.isStopped = false;
            agent.speed = 6.0f;
            yield return new WaitForSeconds(2);
            WaitingForPatrol = false;
        }

        IEnumerator SpeedReset()
        {
            yield return new WaitForSeconds(2);
            agent.speed = 0.0f;
        }

        IEnumerator WaitForPatrol()
        {
            agent.isStopped = true;
            PatrolWaitTime = Random.Range(3, 11);
            yield return new WaitForSeconds(PatrolWaitTime);
            agent.isStopped = false;
            agent.speed = 5.0f;
        }
    }
