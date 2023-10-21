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
    Vector2 forceToApply;
    Vector2 PlayerInput;
    public int antsAlive;
    //private GameObject text;
    Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //text = GameObject.FindGameObjectWithTag("Text");
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        
            PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // text.GetComponent<TMP_Text>().text = antsAlive.ToString();
        Escape();
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
         AnimateCharacter();
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
}
