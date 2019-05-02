using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{

    Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
