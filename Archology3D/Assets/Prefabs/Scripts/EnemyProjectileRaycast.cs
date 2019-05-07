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
        Vector3 shootDir = chaseDirection;
        RaycastHit hit;
        if (chaseDirection.magnitude < chaseTriggerDistance && timer > 2.5f)
        {
           
        }
    }
}
