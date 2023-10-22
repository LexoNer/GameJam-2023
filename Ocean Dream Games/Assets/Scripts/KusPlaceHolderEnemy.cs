using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusPlaceHolderEnemy : MonoBehaviour
{
    public float life = 10f;

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
        print("Life = " + life);

        if(life <= 0)
        {
            Destroy(gameObject);
        }
       
    }

    
}
