using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI2 : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public int numm;
    public GameObject self;
    public bool hasWaited;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        hasWaited = false;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;


            if (timer >= wanderTimer && hasWaited == true)
            {
                hasWaited = false;
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
            if (hasWaited == false)
            {
            StartCoroutine(Timer());
            }
        
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(8);
        hasWaited = true;
    }

}