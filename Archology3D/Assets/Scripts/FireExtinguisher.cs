using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    Camera camera;
    public GameObject Extinguisher;
    public bool HasExtinguisher;
    public GameObject prefab;
    public float bulletSpeed = 100.0f;


    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "Weapon")
            {
                Destroy(gameObject);
                HasExtinguisher = true;
            }
        }
        RaycastHit hit;
        if ( HasExtinguisher == true && Input.GetButtonDown("Fire1") )
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
/*Vector3 destination;
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
*/
