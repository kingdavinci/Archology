using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            Debug.Log(Collision.gameObject.name);
            Collision.gameObject.GetComponentInChildren<PlayerExtinguisher>().HasExtinguisher = true;
            
            Destroy(gameObject);
        }
    }
}