using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]  
public class ProjectileAddon : MonoBehaviour
{
    public float damage;

    private Rigidbody2D rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<KusPlaceHolderEnemy>() != null)
        {
            KusPlaceHolderEnemy enemy = collision.gameObject.GetComponent<KusPlaceHolderEnemy>();
            enemy.receiveAttack(damage);
            Debug.Log("isWorking");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    
}
