using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public  GameObject hormigaObrera;
    private HormigaObrera hormiga;
    private Animator animator;
    private bool canAttack;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float velocity;
    [SerializeField] private float attack;
    [SerializeField] private float timeAttack;
    [SerializeField] private Transform targetAttack;
    [SerializeField] private float waitTime;

    public float life = 10f;


    //posicion segun tipo de enemigo
    public float posX;
    public float posY;

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
        print("Life = " + life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        animator = GetComponent<Animator>();
        animator.SetFloat("Blend",0);
        

        hormigaObrera = gameManager.hormigasObreras[UnityEngine.Random.Range(0, gameManager.hormigasObreras.Count)];
        target = hormigaObrera.transform;
        hormiga = hormigaObrera.GetComponent<HormigaObrera>();
        canAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hormigaObrera == null)
        {
            selectNewHormiga();
        }
        if (Vector3.Distance(transform.position, targetAttack.position) < 15)
        {
            canAttack = true;
        }

        if (canAttack)
        {
            if(hormigaObrera != null)
            {
                float step = velocity * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x + posX, target.position.y - posY, target.position.z), step);
        
                if(timeAttack > 1)
                {
                    timeAttack -= Time.deltaTime;

                    if(timeAttack > 1 && timeAttack < 4 )
                        animator.SetFloat("Blend", 0);
                   
                }
                else if(Vector3.Distance(transform.position, target.position) < .9f )
                {
                    print("Attack");
                    animator.SetFloat("Blend", 1);
                    hormiga.receiveAttack(attack);
                    if (hormiga.life <= 0)
                    {
                       
                        gameManager.hormigasObreras.Remove(hormigaObrera);
                        Destroy(hormigaObrera);
                        selectNewHormiga();
                    }

                    timeAttack = 5;

                }
                
            }
        }
        
        
    }


    public void selectNewHormiga()
    {
        //if(hormigaObrera != null)
        {
          
            hormigaObrera = gameManager.hormigasObreras[UnityEngine.Random.Range(0, gameManager.hormigasObreras.Count)];
            target = hormigaObrera.transform;
            hormiga = hormigaObrera.GetComponent<HormigaObrera>();

        }
    }

}
