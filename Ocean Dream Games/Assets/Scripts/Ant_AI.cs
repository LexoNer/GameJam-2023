using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ant_AI : MonoBehaviour
{
    Rigidbody2D rb;
    public float aiSpeed;
    float speed;

    public float maxTime;
    public float minTime;

    float seconds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = aiSpeed;
       //Debug.Log("speed: " + speed);
        seconds = 5f;
    }

    private void Update()
    {
        AiCommand();
        AntStun();
    }
    void AiCommand()
    {        
            Vector2 newVelocity = new Vector2(aiSpeed, 0);
            rb.velocity = newVelocity;        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "AntKiller")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Player")
        {

            aiSpeed = speed;

            
        }

    }

    void AntStun()
    {
        if (seconds <= 0)
        {
            seconds = Random.Range(minTime, maxTime);
           // Debug.Log("seconds: " + seconds);
            aiSpeed = 0;
        }

        if (seconds > 0 && aiSpeed == speed)
        {
            seconds -= Time.deltaTime;
            //Debug.Log(seconds);
        }
    }



}
