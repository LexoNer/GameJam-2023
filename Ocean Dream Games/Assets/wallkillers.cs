using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallkillers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HormigaObrera>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
