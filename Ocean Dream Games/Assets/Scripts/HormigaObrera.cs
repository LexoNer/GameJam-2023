using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HormigaObrera : MonoBehaviour
{
    public float life = 100;
    public bool run;

    public float duracion = 2.0f;
    private bool enMovimiento;
    [SerializeField] private Transform primerPosicion;
    public float velocity;
    bool inAttacking;
    public bool firstAnt;
    Vector3 posicionInicial;

    [SerializeField] GameManager gameManager;


    [Header("KusAdded")]
    private bool canMove;
    public float maxTime;
    public float minTime;
    private float seconds;
    private float normalVelocity;


    Animator animator;  

    //Time of the ant lost
    [SerializeField]float timeAntLost;
    // Start is called before the first frame update
    void Awake()
    {
        timeAntLost = Random.Range(3, 7);
        this.transform.position = primerPosicion.position;
        animator = GetComponent<Animator>();
        seconds = 5f;
        normalVelocity = velocity;
        //canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = primerPosicion.position;

        AntStun();

        // animator.SetFloat("Blend", 1f);


        if (!inAttacking)
        
        {
            //if{isBossAtacking}
            //{
            //  canMove = false;
            //
            //}

            animator.SetFloat("Blend", 1f);
            float step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(primerPosicion.position.x, primerPosicion.position.y, primerPosicion.position.z), step);
        }

        
        if (Input.GetKeyDown("space"))
        {
                    StartCoroutine(huir(false));
        }
        

        /*if (timeAntLost > 0)
        {
            timeAntLost -= Time.deltaTime;
        }
        else
        {
            int probably = Random.Range(0, 11);
            print("Probably = " + probably);
            if (probably <= 4)
            {
                StartCoroutine(huir(true));
            }
            timeAntLost = Random.Range(5, 10);
        }*/
    }

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
        print("Life = " + life);
        run = true;
        inAttacking = true;

        if (!gameManager.bossFight)
        {
            StartCoroutine(huir(true));
        }
        
    }

    IEnumerator huir(bool enemyAttack)
    {
        if (!gameManager.bossFight)
        {
            yield break;
        }

        if (enMovimiento && enemyAttack)
        {
            yield break;
        }

        enMovimiento = true;
      //  animator.SetFloat("Blend", 1);
        
        
        float random1 = Random.Range(-4.5f, 5.1f);
        float random2 = Random.Range(-2.5f, 1.5f);
        Vector3 targetpoint;
        if (enemyAttack)
        {
            targetpoint = new Vector3(transform.position.x + random1, transform.position.y + random2, transform.position.z);
            duracion = 2f;
            animator.SetFloat("Blend", 1);
        }
        else
        {
            targetpoint = new Vector3(primerPosicion.position.x, primerPosicion.position.y, primerPosicion.position.z);
            duracion = 0.1f;
            animator.SetFloat("Blend", 1);
        }
        float tiempoPasado = 0f;
        posicionInicial = transform.position;

        while(tiempoPasado < duracion)
        {
            float t = tiempoPasado / duracion;
            transform.position = Vector3.Lerp(posicionInicial, targetpoint, t);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        transform.position = targetpoint;
        enMovimiento = false;
        animator.SetFloat("Blend", 0f);
        inAttacking = false;

        
    }

    public void StartCorrutina()
    {
        if (!gameManager.bossFight)
        {
            StartCoroutine(huir(true));
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if (other.tag == "Player")
        {
            velocity = normalVelocity;
   
            animator.SetFloat("Blend", 1f);
        }

        if(other.tag == "AntKiller")
        {
            Destroy(gameObject);
        }
        */
    }

    void AntStun()
    {
        if (seconds <= 0)
        {
            seconds = Random.Range(minTime, maxTime);
            // Debug.Log("seconds: " + seconds);
            velocity = 0;
        }

        if (seconds > 0 && velocity == normalVelocity)
        {
            seconds -= Time.deltaTime;
            //Debug.Log(seconds);
        }
    }

}
