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
   public Animator animator;

    [SerializeField] GameManager gameManager;


  /*  [Header("KusAdded")]
    private bool canMove;
    public float maxTime;
    public float minTime;
    private float seconds;
    private float normalVelocity;
*/



    //Time of the ant lost
    [SerializeField]float timeAntLost;
    // Start is called before the first frame update
    void Start()
    {
      //  animator = GetComponent<Animator>();
        timeAntLost = Random.Range(3, 7);
        this.transform.position = primerPosicion.position;
        print("FUNCIONA");



        //  seconds = 5f;
        //  normalVelocity = velocity;
        //canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        // AntStun();

       animator.SetFloat("Blend", 1);

        if (!inAttacking)
        {
         //   animator.SetFloat("Blend", 1f);

            float step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), step);
        }


        if (Input.GetKeyDown("space"))
        {
                StartCoroutine(huir(false));
        }
        

        
    }

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
        print("Life nn= " + life);
        run = true;
        inAttacking = true;

        if (!gameManager.bossFight)
        {
            StartCoroutine(huir(true));
        }
        
    }

    IEnumerator huir(bool enemyAttack)
    {

        yield return new WaitForSeconds(1f);
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
            duracion = 1f;
          //  animator.SetFloat("Blend", 1);
        }
        else
        {
            targetpoint = new Vector3(primerPosicion.position.x, primerPosicion.position.y, primerPosicion.position.z);
            duracion = 0.1f;
           // animator.SetFloat("Blend", 1);
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
      //  animator.SetFloat("Blend", 0f);
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
    {
        if(other.tag == "Player")
        {
            StartCoroutine(huir(false));

        }
    }






}
