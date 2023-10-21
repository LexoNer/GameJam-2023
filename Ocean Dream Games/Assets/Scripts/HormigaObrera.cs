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
    private Vector3 primerPosicion;
    // Start is called before the first frame update
    void Start()
    {
        primerPosicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(huir(false));
        }
    }

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
        print("Life = " + life);
        run = true;
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
            targetpoint = primerPosicion;
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
}
