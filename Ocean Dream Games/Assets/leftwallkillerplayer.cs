using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftwallkillerplayer : MonoBehaviour
{
    private void OnColliderEnter2D(Collider2D other)
    {
       if( other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Destroy(other.gameObject);  
        }
        if (other.gameObject.GetComponent<HormigaObrera>() != null)
        {
            Destroy(other.gameObject);
        }
    }

   
}
