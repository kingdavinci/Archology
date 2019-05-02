using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(EnemyNavMov))]
public class NavMeshAgentTurnOff : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            agent.enabled = false;
            GetComponent<EnemyNavMov>().enabled = false;
        }
        if (collision.gameObject.tag == "ground" && !(collision.gameObject.tag == "Player"))
        {
            agent.enabled = true;
            GetComponent<EnemyNavMov>().enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //if(collision.gameObject.tag == "ground")
        {
           // agent.enabled = false;
           // GetComponent<EnemyNavMov>().enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!(collision.gameObject.tag == "ground"))
        {
            agent.enabled = false;
            GetComponent<EnemyNavMov>().enabled = false;
        }
    }
}
