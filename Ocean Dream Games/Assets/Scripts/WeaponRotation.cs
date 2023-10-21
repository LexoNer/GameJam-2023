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


        //float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        //aimTransform.eulerAngles = new Vector3(0,0, angle);
        //attackPoint.eulerAngles = new Vector3(0,0, angle);

        //Debug.Log(angle);
        //Debug.Log(aimTransform.eulerAngles);
    }

}
