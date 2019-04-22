using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyNavMov : MonoBehaviour
{
    //use this for initalization
    //store new mesh agent
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public float chaseDistance = 10;
    private Vector3 home;
    private void Start()
    {
        home = transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        //move object twords destionation
        Vector3 direction = player.transform.position - transform.position;
        if(direction.magnitude <= chaseDistance)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = home;
        }
    }
}
