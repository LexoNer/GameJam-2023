using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{

    public GameObject hormigaObrera;  // El punto A como objeto transform
    public Transform puntoB;  // El punto B como objeto transform
    public float duracion = 2.0f;  // Duración del movimiento en segundos

    public GameManager manager;

    private bool enMovimiento = false;

    void Start()
    {
        // Iniciar la corrutina cuando sea necesario
        StartCoroutine(Boss());
    }

    IEnumerator Boss()
    {
        if (enMovimiento)
        {
            yield break; // Evitar iniciar otra vez mientras se está moviendo
        }

        enMovimiento = true;

        float tiempoPasado = 0f;
        Vector3 posicionInicial = transform.position;
        hormigaObrera = manager.hormigasObreras[Random.Range(0, manager.hormigasObreras.Count)];
        puntoB = hormigaObrera.transform;

        while (tiempoPasado < duracion)
        {
            // Calcular la nueva posición interpolando entre A y B
            float t = tiempoPasado / duracion;
            transform.position = Vector3.Lerp(posicionInicial, puntoB.position, t);

            // Actualizar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null; // Esperar hasta el próximo frame
        }

        // Asegurarse de que el objeto esté en el punto B al final
        transform.position = puntoB.position;
        enMovimiento = false;

        print("Attack");
        StartCoroutine(waitToAttack());
    }


    IEnumerator waitToAttack()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(Boss());
    }
}


