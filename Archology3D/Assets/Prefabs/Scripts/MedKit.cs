using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedKit : MonoBehaviour
{
    public int Health;
    public GameObject Player;
    public Text Text;
    private float timer;
    private bool timerStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart)
        {
            timer += Time.deltaTime;
            if(timer >= 3.5)
            {
                Text.enabled = false;
                timerStart = false;
                timer = 0;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "MedKit")
        {
            Text.enabled = true;
            timerStart = true;
            Player.GetComponent<PlayerHP>().HP += Health;
            Destroy(gameObject);
        }
    }
}
