using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public bool grounded;
    public Rigidbody PlayerRB;
    private float airTime;
    public int HP = 10;
    public Text HPText;
   // public float fallHeight = 7f;
   // float y = PlayerRB.velocity.y;
   // public Slider HPBar;
   // public GameObject Deathcanvas;
    float timer = 0;

     void Update()   
     {
      //  Debug.Log(PlayerRB.velocity.y);
        HPText.GetComponent<Text>().text = "Health: " + HP;
        timer += Time.deltaTime;

        if (grounded == false)
        {
            airTime += Time.deltaTime;
            //Debug.Log(airTime);
           // if (airTime >= 2.0)
          //  {
           //     HP--;
            //    Debug.Log("check");
           //     Debug.Log(HP);
           // }
        }
        if ( PlayerRB.velocity.y <= -15)
        {
            HP-= 10;
         //   Debug.Log("check");
          //  Debug.Log(HP);
        }
        if (grounded == true)
        {
            airTime = 0;
        }
        if (HP <= 0 && grounded)
        {
            SceneManager.LoadScene("LoseScene");
        }
        if(HP <= -10)
        {
            SceneManager.LoadScene("LoseScene");
        }
     }
    void Start()
    {
        HPText.GetComponent<Text>().text = "Health: " + HP;
        //  HPBar.GetComponent<Slider>().value = HP;
        PlayerRB = GetComponent<Rigidbody>();
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
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Ground")
        {
            grounded = true;
           // Debug.Log("grounded");
        }
        else if(Collision.gameObject.tag == "Ground" && HP <=0)

        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    //if character is jumping
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            grounded = false;
            //Debug.Log("ungrounded");
        }
    }



}
