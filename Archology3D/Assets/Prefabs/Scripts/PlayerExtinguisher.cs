using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtinguisher : MonoBehaviour
{
    Camera camera;
    public GameObject Extinguisher;
    public bool HasExtinguisher;
    public float bulletSpeed = 50.0f;
    public GameObject prefab;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (HasExtinguisher == true)
        {
            Extinguisher.SetActive(true);
        }
        if (HasExtinguisher == false)
        {
            Extinguisher.SetActive(false);
        }
        RaycastHit hit;
        
        if (HasExtinguisher == true && Input.GetButtonDown("Fire1"))
        {
            Vector3 destination;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                destination = hit.point;
            }
            else
            {
                //still want to shoot
                destination = camera.transform.position + 50 * camera.transform.forward;
            }
            Vector3 velocity = destination - transform.position;
            velocity.Normalize();
            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = velocity * bulletSpeed;
            HasExtinguisher = false;
            
        }
    }
}
/*{
destination = camera.transform.position + 50 * camera.transform.forward;
Vector3 velocity = destination - transform.position;
velocity.Normalize();
GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
projectile.GetComponent<Rigidbody>().velocity = velocity * bulletSpeed;
HasExtinguisher = false;
}*/
