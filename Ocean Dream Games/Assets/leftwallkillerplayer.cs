using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftwallkillerplayer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnColliderEnter2D(Collider2D other)
    {
       if( other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Destroy(other.gameObject);  
        }
        if (other.gameObject.GetComponent<HormigaObrera>() != null)
        {
            Destroy(other.gameObject);
            gameManager.hormigasObreras.Remove(other.gameObject);
        }
    }

   
}
