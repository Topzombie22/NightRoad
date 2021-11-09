using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chas : MonoBehaviour
{
    BoxCollider boxCol;

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
    public bool isBlind;

    public float chaseTime = 100.0f;
    private float chaseRate = 12.5f;

    public float waitTime = 100.0f;
    private float waitRate = 25.0f;

    public float visionTime = 100.0f;
    private float visionRate = 25.0f;



    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider>();
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
        {
            GotoNextPoint();
        }
        Chasing();
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
            alerted = true;
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

                if (destPoint >= 8)
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

                if (destPoint <= 12)
                {
                    destPoint = 12;
                }

                if (destPoint >= 16)
                {
                    destPoint = 12;
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

                if (destPoint <= 16)
                {
                    destPoint = 16;
                }

                if (destPoint >= 20)
                {
                    destPoint = 16;
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

                if (destPoint <= 20)
                {
                    destPoint = 20;
                }

                if (destPoint >= 24)
                {
                    destPoint = 20;
                }
            }
        }
    }

    public void Chasing()
    {
        if (alerted == true)
        {
            agent.SetDestination(target.position);
            boxCol.enabled = false;
            agent.isStopped = true;
            MonsterScream.Play();
            anima.SetBool("alerted", alerted);
            waitTime = waitTime - waitRate * Time.deltaTime;

            if (waitTime <= 0)
            {
                anima.SetBool("alerted", alerted);
                chaseTime = 100.0f;
                chasingPlayer = true;
            }
        }

        if (chasingPlayer == true)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            MonsterRunning.Play();
            waitTime = 100.0f;
            chaseTime = chaseTime - chaseRate * Time.deltaTime;
            if (chaseTime >= 60.0f)
            {
                agent.speed = 6.0f;
            }
            if (chaseTime <= 59.99f)
            {
                agent.speed = 12.0f;
            }
            if (chaseTime <= 0.0f)
            {
                chaseTime = 100.0f;
                agent.isStopped = true;
                chasingPlayer = false;
                isBlind = true;
                alerted = false;
            }

        }
        if (isBlind == true)
        {
            boxCol.enabled = false;
            visionTime = visionTime - visionRate * Time.deltaTime;

            if (visionTime <= 0.0f)
            {
                boxCol.enabled = true;
                agent.isStopped = false;
                visionTime = 100.0f;
                isBlind = false;
            }
        }
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
