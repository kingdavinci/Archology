using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroytheDrone : MonoBehaviour
{
    public GameObject Extinguisher;

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}