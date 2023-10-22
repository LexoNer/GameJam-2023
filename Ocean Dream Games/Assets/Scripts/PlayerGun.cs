using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform attackPoint;
    public Transform aim;
  //  public Transform attackTarget;
    public GameObject bullet;

    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse1;
    public float throwForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        print("lemon");

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        Vector2 forceDirection = attackPoint.transform.right; //attackTarget.transform.position += forceDirection;

        Vector2 forceToAdd = forceDirection * throwForce;

        projectileRb.AddForce(forceToAdd, ForceMode2D.Impulse);

        Invoke(nameof(ResetThrow), throwCooldown);
    }


    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
