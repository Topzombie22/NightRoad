using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRay : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NavMeshHit hit;
        if (!agent.Raycast(target.position, out hit))
        {
            Debug.Log("Fuck");
        }
    }

}