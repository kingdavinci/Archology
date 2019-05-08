using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileRaycast : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject prefab;
    Vector3 Distance;
    public float DistanceFrom;
    public float timer = 0;
    public float shootSpeed = 10;
    public bool IsAttacking;

    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 EnemyPosition = transform.position;
        Distance = (EnemyPosition - PlayerPosition);
        DistanceFrom = Distance.magnitude;

        // if enemy 20 from player attack
        if (DistanceFrom >= 10.0)
        {
            IsAttacking = true;
        }
        if (DistanceFrom <= 10.0)
        {
            IsAttacking = false;
        }

        Vector3 destination;
        if (IsAttacking == true)
        {
            destination = EnemyPosition - PlayerPosition;
            Vector3 velocity = destination - transform.position;
            velocity.Normalize();
            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = velocity * shootSpeed;
        }
    }
}



/*public GameObject player;
    public float chaseTriggerDistance = 3.0f;
    public GameObject prefab;
    public float shootSpeed = 10;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDirection = playerPosition - transform.position;
        Vector3 shootDir = chaseDirection;
        RaycastHit hit;
        if (chaseDirection.magnitude < chaseTriggerDistance && timer > 2.5f)
        {
           
        }
    }
*/