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
    public int antsAlive;
    //private GameObject text;
    Animator animator;
    bool playerCanMove;
    public GameObject attackHitBox;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //text = GameObject.FindGameObjectWithTag("Text");
       animator = GetComponent<Animator>();
        playerCanMove = true;
        attackHitBox.SetActive(false);
        speed = moveSpeed;
    
    }

    void Update()
    {
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
        if (PlayerInput.x == 0 && PlayerInput.y == 0)
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", 0);

        }

        if (PlayerInput.y == 1)
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);
        }
        if (PlayerInput.y == -1)
        {
           animator.SetFloat("Vertical", -1);
           animator.SetFloat("Horizontal", 0);
        }
        if (PlayerInput.x == -1)
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", -1);
        }
        if (PlayerInput.x == 1)
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", 1);
        }

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
        if (other.tag == "AntKiller")
        {
            Destroy(gameObject);
        } 
    }


    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerCanMove = false;
            attackHitBox.SetActive(true);
            moveSpeed = 0;

            animator.SetFloat("Vertical", 2);
            animator.SetFloat("Horizontal", 2);
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
