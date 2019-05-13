using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireExtinguisher : MonoBehaviour
{
    //public Text Text;
    private float timer;
    private bool timerStart = false;
    public GameObject text;
    public bool rebound = false;
    public int Knockback = 50;
    public GameObject Extinguisher;

    void Update()
    {
        /*if (timerStart)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 3.5)
            {
                Text.enabled = false;
                timerStart = false;
                timer = 0;
            }
        }*/
        if (rebound == true)
        {
            Debug.Log("running");
            Knockback = Mathf.RoundToInt(GetComponent<Rigidbody>().velocity.magnitude) * 8;
            /*if ((Extinguisher.transform.position - transform.position).magnitude > 5)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3((Extinguisher.transform.position - transform.position).normalized.x, (Extinguisher.transform.position - transform.position).normalized.y) * 5);
                Debug.Log("not rebound");
            }
            else
            {*/
            Debug.Log("rebounding");
            GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6));
            rebound = false;
            //}
        }
    }
    void OnCollisionEnter(Collision Collision)
    {
        if (!(Collision.gameObject.tag == "ground"))
        {
            rebound = true;
        }
        if (Collision.gameObject.tag == "Player")
        {
            //Text.enabled = true;
            timerStart = true;
            Debug.Log(Collision.gameObject.name);
            Collision.gameObject.GetComponentInChildren<PlayerExtinguisher>().HasExtinguisher = true;
            Destroy(gameObject);
            text.GetComponent<CallUponText>().timer = 0;
            //GetComponent<MeshCollider>().enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void OnCollisionExit(Collision Collision)
    {
        rebound = false;
    }
}