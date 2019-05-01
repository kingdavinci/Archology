using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtinguisher : MonoBehaviour
{
    Camera camera;
    public GameObject Extinguisher;
    public bool HasExtinguisher;
    public float bulletSpeed = 100.0f;
    public GameObject prefab;
    // Update is called once per frame
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
            destination = camera.transform.position + 50 * camera.transform.forward;
            Vector3 velocity = destination - transform.position;
            velocity.Normalize();
            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = velocity * bulletSpeed;
            HasExtinguisher = false;
        }
    }
}
