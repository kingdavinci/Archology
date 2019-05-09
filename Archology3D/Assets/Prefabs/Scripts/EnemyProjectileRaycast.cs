using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileRaycast : MonoBehaviour
{
    Vector3 Distance;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject prefab;
    public float DistanceFrom;
    public float timer = 0;
    public float shootSpeed = 20;
    public bool IsAttacking;

    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 EnemyPosition = transform.position;
        Distance = (EnemyPosition - PlayerPosition);
        DistanceFrom = Distance.magnitude;

        // if enemy 15 from player attack
        if (DistanceFrom <= 15.0)
        {
            IsAttacking = true;
        }
        if (DistanceFrom >= 15.0)
        {
            IsAttacking = false;
        }

        //attack
        Vector3 destination;
        timer += Time.deltaTime;
        if (IsAttacking == true && timer >= 0.5f)
        {
            destination = EnemyPosition - PlayerPosition;
            Vector3 velocity = -destination;
            velocity.Normalize();
            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = velocity * shootSpeed;
            Destroy(projectile, 1f);
            timer = 0f;
        }
    }
}