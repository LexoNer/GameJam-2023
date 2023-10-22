using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class WeaponRotation : MonoBehaviour
{
    //public Transform aimTransform;
    //public Transform attackPoint;

    private void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector2 aimDirection = Camera.main.ScreenToWorldPoint(mousePos);

        transform.LookAt(aimDirection);
        
        GameObject cursor = GameObject.Find("cursor");
        cursor.transform.position = aimDirection;

        //Vector2 forceDirection = attackPoint.transform.right;

    }

}
