using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackHitBoxPlayer : MonoBehaviour
{
    public float dmg;
    Transform target;
    int enemiesEncounter;


    private void OnTriggerEnter2D(Collider2D other)
    {
        


        if (other.gameObject.GetComponent<KusPlaceHolderEnemy>() != null)
        {
            print("Attack!");
            other.GetComponent<KusPlaceHolderEnemy>().receiveAttack(dmg);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            enemiesEncounter++;
            print(enemiesEncounter);
            
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.receiveAttack(dmg/enemiesEncounter);
            EndCombat();
        }

        void EndCombat()
        {
            this.gameObject.SetActive(false);
            enemiesEncounter = 0;
        }

    }
}
