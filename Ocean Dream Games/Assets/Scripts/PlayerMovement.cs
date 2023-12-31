using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    float speed;
    Vector2 forceToApply;
    Vector2 PlayerInput;
    //private GameObject text;
     Animator animator;
    bool playerCanMove;
    public GameObject attackHitBox;
    public Transform attackPoint;
    BoxCollider2D bc;
    SpriteRenderer spriteRenderer;





    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //text = GameObject.FindGameObjectWithTag("Text");
       animator = GetComponent<Animator>();
        playerCanMove = true;
        attackHitBox.SetActive(false);
        speed = moveSpeed;
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       // SetAttackPointPosition(attackTargetRight);
    
    }

    private void SetAttackPointPosition(Transform transform)
    {
        attackPoint.position = transform.position;
        attackPoint.rotation = transform.rotation;  
    }

    void Update()
    {
        Vector3 aimDirection = Input.mousePosition;
        aimDirection.z = 10;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(aimDirection);
        

        if(mousePos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }

        Escape();
        PlayerAttack();
        if (playerCanMove)
        {
            PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
          

        // text.GetComponent<TMP_Text>().text = antsAlive.ToString();
    }

    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * moveSpeed;
        moveForce += forceToApply;  
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;
        if(playerCanMove)
        {
            AnimateCharacter();
        }
        
    }

    void AnimateCharacter()
    {
        Vector3 aimDirection = Input.mousePosition;
        aimDirection.z = 10;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(aimDirection);


        if (PlayerInput.x == 0 && PlayerInput.y == 0)
        {
            animator.SetFloat("Horizontal", 0);
        }

        if (mousePos.x < 0)
        {
            if(PlayerInput.x == -1)
            {
                animator.SetFloat("Horizontal", 1);
            }
            else if(PlayerInput.x == 1)
            {
                animator.SetFloat("Horizontal", 2);
            }
        }

        if (mousePos.x > 0)
        {
            if (PlayerInput.x == -1)
            {
                animator.SetFloat("Horizontal", 2);
            }
            else if (PlayerInput.x == 1)
            {
                animator.SetFloat("Horizontal", 1);
            }
        }



        /* if (PlayerInput.y == -1)
         {
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);
           // SetAttackPointPosition(attackTargetDown);
         }
         if (PlayerInput.x == -1)
         {
             animator.SetFloat("Vertical", 0);
             animator.SetFloat("Horizontal", -1);
             //SetAttackPointPosition(attackTargetLeft);
         }
         if (PlayerInput.x == 1)
         {
             animator.SetFloat("Vertical", 0);
             animator.SetFloat("Horizontal", 1);
             //SetAttackPointPosition(attackTargetRight);
         }*/

    }
    void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                                                   Application.Quit();
            #endif
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
     
    }


    void PlayerAttack()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            playerCanMove = false;
            attackHitBox.SetActive(true);
            moveSpeed = 0;
            animator.SetFloat("Horizontal", 3);
        }
    }

    public void ReturnMove()
    {
        Debug.Log(playerCanMove);
        playerCanMove = true;
        Debug.Log(playerCanMove);
        moveSpeed = speed;
        attackHitBox.SetActive(false);
    }




}
