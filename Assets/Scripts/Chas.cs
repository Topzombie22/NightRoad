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
    public Transform PatrolAreaFour;
    public Transform PatrolAreaFive;
    public Transform PatrolAreaSix;

    public bool WaitingForPatrol = false;
    public int PatrolZone;
    public int PatrolWaitTime;

    public float distPatrolOne;
    public float distPatrolTwo;
    public float distPatrolThree;
    public float distPatrolFour;
    public float distPatrolFive;
    public float distPatrolSix;

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
        MonsterRunning.pitch = 0.5f;
        GotoNextPoint();
    }

    void Update()
    {
        anima.SetBool("Moving", isMoving);

        if (agent.isStopped == false)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
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
        distPatrolFour = Vector3.Distance(target.position, PatrolAreaFour.position);
        distPatrolFive = Vector3.Distance(target.position, PatrolAreaFive.position);
        distPatrolSix = Vector3.Distance(target.position, PatrolAreaSix.position);

        if (distPatrolOne < distPatrolTwo && distPatrolOne < distPatrolThree && distPatrolOne < distPatrolFour && distPatrolOne < distPatrolFive && distPatrolOne < distPatrolSix)
        {
            PatrolZone = 1;
        }
        if (distPatrolTwo < distPatrolOne && distPatrolTwo < distPatrolThree && distPatrolTwo < distPatrolFour && distPatrolTwo < distPatrolFive && distPatrolTwo < distPatrolSix)
        {
            PatrolZone = 2;
        }
        if (distPatrolThree < distPatrolOne && distPatrolThree < distPatrolTwo && distPatrolThree < distPatrolFour && distPatrolThree < distPatrolFive && distPatrolThree < distPatrolSix)
        {
            PatrolZone = 3;
        }
        if (distPatrolFour < distPatrolOne && distPatrolFour < distPatrolTwo && distPatrolFour < distPatrolThree && distPatrolFour < distPatrolFive && distPatrolFour < distPatrolSix)
        {
            PatrolZone = 4;
        }
        if (distPatrolFive < distPatrolOne && distPatrolFive < distPatrolTwo && distPatrolFive < distPatrolThree && distPatrolFive < distPatrolFour && distPatrolFive < distPatrolSix)
        {
            PatrolZone = 5;
        }
        if (distPatrolSix < distPatrolOne && distPatrolSix < distPatrolTwo && distPatrolSix < distPatrolThree && distPatrolSix < distPatrolFour && distPatrolSix < distPatrolFive)
        {
            PatrolZone = 6;
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
            chasingPlayer = true;
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
        if (chasingPlayer == false)
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
            if (PatrolZone == 4)
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

                if (destPoint <= 11)
                {
                    destPoint = 8;
                }

                if (destPoint >= 12)
                {
                    destPoint = 8;
                }
            }
            if (PatrolZone == 5)
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
            if (PatrolZone == 6)
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
    }
            IEnumerator Timer()
            {
            agent.isStopped = true;
            anima.SetBool("alerted", true);
            agent.speed = 6.0f;
            yield return new WaitForSeconds(4);
            agent.isStopped = false;
            MonsterRunning.Play();
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
            agent.speed = 6.0f;
        }

        IEnumerator WaitingSound()
        {
            agent.isStopped = true;
            agent.SetDestination(target.position);
            yield return new WaitForSeconds(2);
            agent.isStopped = false;
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
        }
    }
