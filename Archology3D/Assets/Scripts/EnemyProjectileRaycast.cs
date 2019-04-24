using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileRaycast : MonoBehaviour
{
    public GameObject player;
    public float chaseTriggerDistance = 3.0f;
    public GameObject prefab;
    public float shootSpeed = 10;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDirection = playerPosition - transform.position;
        if (chaseDirection.magnitude < chaseTriggerDistance && timer > 2.5f)
        {
            timer = 0;
            Vector3 shootDir = chaseDirection;
            shootDir.Normalize();
            Vector3 offset = shootDir;
            shootDir = shootDir * shootSpeed;
            //when calculating a vector from a to b
            //always do destination - start position
            GameObject Bullet = (GameObject)Instantiate(prefab, transform.position + offset, Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().velocity = shootDir;
        }
    }
}
