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
    public int velocity;
    bool inAttacking;
    public bool firstAnt;
    Vector3 posicionInicial;

    //Time of the ant lost
    [SerializeField]float timeAntLost;
    // Start is called before the first frame update
    void Awake()
    {
        timeAntLost = Random.Range(3, 7);
        transform.position = primerPosicion.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inAttacking)
        {
            float step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), step);
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
        StartCoroutine(huir(true));
    }

    IEnumerator huir(bool enemyAttack)
    {
        if (enMovimiento && enemyAttack)
        {
            yield break;
        }

        enMovimiento = true;
        
        
        float random1 = Random.Range(-5, 6);
        float random2 = Random.Range(-4, 4);
        Vector3 targetpoint;
        if (enemyAttack)
        {
            targetpoint = new Vector3(transform.position.x + random1, transform.position.y + random2, transform.position.z);
            duracion = 2f;
        }
        else
        {
            targetpoint = new Vector3(primerPosicion.position.x, primerPosicion.position.y, primerPosicion.position.z);
            duracion = 0.1f;
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
        inAttacking = false;

        
    }

    public void StartCorrutina()
    {
        StartCoroutine(huir(true));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AntKiller")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {

        }

    }
}
