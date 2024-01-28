using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimmyControll : MonoBehaviour
{
     
    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;


    public int score;
    public Text textScore;


    AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        score = 0;

        audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //translation 
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
        
        if (translation !=0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }






        // Vérifier si le score est égal à zéro
        if (score <= 0)
        {
            // Déclencher l'animation de mort
            anim.SetTrigger("death");
        }
        



    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="coin")
        {
          
            Destroy(other.gameObject);
            score = score + 1;
            textScore.text = "score:" + score;
            audioS.Play();



        }

        if (other.tag == "coin2")
        {

            Destroy(other.gameObject);
            score = score + 5;
            textScore.text = "score:" + score;
            audioS.Play();




        }

        if (other.tag == "coin3")
        {

            Destroy(other.gameObject);
            score = score -5;
            textScore.text = "score:" + score;
            audioS.Play();



        }


    }


    

}
