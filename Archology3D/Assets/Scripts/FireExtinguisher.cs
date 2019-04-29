using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public GameObject Extinguisher;

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "Weapon")
            {
                Destroy(gameObject);
            }
        }
    }
}
