using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int Health;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "MedKit")
        {
            Player.GetComponent<PlayerHP>().HP += Health;
            Destroy(gameObject);
        }
    }
}
