using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public bool grounded;
    private float airTime;
    public int HP = 10;
    public Text HPText;
  //  public Slider HPBar;
   // public GameObject Deathcanvas;
    float timer = 0;

     void Update()
    {
        timer += Time.deltaTime;

        if (grounded == false)
        {
            airTime += Time.deltaTime;
            //Debug.Log(airTime);
            if (airTime >= 2.0)
            {
                HP--;
                Debug.Log("check");
            }
        }
        else if (grounded == true)
        {
            airTime = 0;
        }

        
    }
    void Start()
    {
        HPText.GetComponent<Text>().text = "Health: " + HP;
        //  HPBar.GetComponent<Slider>().value = HP;
    }


    void OnCollisionStay(Collision collision)
    {
        if (timer > 0.5f && collision.gameObject.tag == "Enemy" || timer > 0.5f && collision.gameObject.tag == "Boss")
            {
            timer = 0;
            HP--;
            HPText.GetComponent<Text>().text = "Health: " + HP;
           // HPBar.GetComponent<Slider>().value = HP;
            if (HP <= 0)

            {
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
    //are you on the ground
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("grounded");
        }
    }

    //if character is jumping
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            grounded = false;
            Debug.Log("ungrounded");
        }
    }


}
