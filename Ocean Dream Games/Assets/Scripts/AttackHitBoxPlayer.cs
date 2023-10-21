using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBoxPlayer : MonoBehaviour
{
    public float dmg; 


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Enemy")
        {

            print("Attack!");
            other.GetComponent<KusPlaceHolderEnemy>().receiveAttack(dmg);
            this.gameObject.SetActive(false);

          
        }
    }
}
