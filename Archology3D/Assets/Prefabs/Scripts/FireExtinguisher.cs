using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            Collision.gameObject.GetComponent<PlayerExtinguisher>().HasExtinguisher = true;
            Destroy(gameObject);
        }
    }
}