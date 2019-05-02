using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {
    public GameObject player;
    public float chaseSpeed = 15.0f;
    public float chaseTriggerDistance = 30.0f;
    Vector3 startPosition;
    bool home = true;
    public Vector3 paceDirection;
    public float paceDistance = 3.0f;
    public float paceSpeed = 2.0f;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        paceDirection.Normalize();
    }

    // Update is called once per frame
    void Update() {
        Vector3 playerPosition = player.transform.position;
        // vector from the enemy position to the player position
        Vector3 chaseDirection = playerPosition - transform.position;
        // if the player is 4 away and the trigger distance is 5 then start chasing
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            //Chase because the player is close to the enemy
            home = false;
            chaseDirection.Normalize();
            GetComponent<Rigidbody>().velocity = chaseDirection * chaseSpeed;
            // runs if the player is not close enough to the enemy
        } else if (home == false)
        {
            //see how far way we are from home
            Vector3 homeDirection = startPosition - transform.position;
            // if close to home, reset our position to home and reset our velocity
            if (homeDirection.magnitude < 0.3f)
            {
                home = true;
                transform.position = startPosition;
                GetComponent<Rigidbody>().velocity = new Vector3(0, -30, 0);
            } else
            {
                //go home
                homeDirection.Normalize();
                GetComponent<Rigidbody>().velocity = homeDirection * paceSpeed;
            }

        }
        else
        {
            Vector3 displacement = transform.position - startPosition;
            float distanceFromStart = displacement.magnitude;
            if (distanceFromStart >= paceDistance)
            {
                // flip directions
                displacement.Normalize();
                paceDirection = -displacement;
            }
            paceDirection.Normalize();
            GetComponent<Rigidbody>().velocity = paceDirection * paceSpeed;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            chaseSpeed = 0.0f;
            Debug.Log("hit");
            paceSpeed = 0;
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        chaseSpeed = 15.0f;
        paceSpeed = 2.0f;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //paceDirection = new Vector3(0, -7, 0);
            chaseSpeed = -7.0f;
        }
    }
}
