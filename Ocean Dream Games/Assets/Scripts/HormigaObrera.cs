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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*if (!inAttacking)
        {
            float step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), step);
        }*/


        if (Input.GetKeyDown("space") && inAttacking)
        {
            StartCoroutine(huir(false));
        }
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
        if (enMovimiento)
        {
            yield break;
        }

        enMovimiento = true;
        
        
        int random1 = UnityEngine.Random.Range(-2, 3);
        int random2 = UnityEngine.Random.Range(-2, 3);
        Vector3 targetpoint;
        if (enemyAttack)
        {
            targetpoint = new Vector3(transform.position.x + random1, transform.position.y + random2, transform.position.z);
        }
        else
        {
            targetpoint = new Vector3(primerPosicion.position.x, primerPosicion.position.y, primerPosicion.position.z);
        }
        float tiempoPasado = 0f;
        Vector3 posicionInicial = transform.position;

        while(tiempoPasado < duracion)
        {
            float t = tiempoPasado / duracion;
            transform.position = Vector3.Lerp(posicionInicial, targetpoint, t);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        transform.position = targetpoint;
        enMovimiento = false;

        
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
