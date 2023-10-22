using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]  
public class ProjectileAddon : MonoBehaviour
{
    public float damage;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.GetComponent<KusPlaceHolderEnemy>() != null)
        {
            KusPlaceHolderEnemy enemy = collision.gameObject.GetComponent<KusPlaceHolderEnemy>();
            enemy.receiveAttack(damage);
            Debug.Log("isWorking");
            Destroy(gameObject);
        }*/
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.receiveAttack(damage);
            Debug.Log("isWorking");
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<BossLogic>()!= null)
        {
            BossLogic bossLogic = collision.gameObject.GetComponent<BossLogic>();
            bossLogic.receiveAttack(damage);
           // Debug.Log("IS WORKING, IS WORKIIIIING");
            Destroy(gameObject);

        }
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<BossLogic>().receiveAttack(damage);
           // Debug.Log("IS WORKING, IS WORKIIIIING");
            Destroy(gameObject);

        }


        else
        {
            Destroy(gameObject);
        }
    }

    

    
    
}
