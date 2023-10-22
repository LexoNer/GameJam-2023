using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLogic : MonoBehaviour
{

    public GameObject hormigaObrera;  // El punto A como objeto transform
    public Transform puntoB;  // El punto B como objeto transform
    public float duracion = 2.0f;  // Duración del movimiento en segundos

    public GameManager manager;

    private bool enMovimiento = false;
    public Animator animator;
    bool ataqueAnt;
    public int lifeoftheboss = 100;

    //Hola! Kus al habla, voy a hacerle una vida rapidamente al jefe para poder derrotarlo y llevar al jugador a la escena de victoria, asi para confirmar
    // que todo respecto al dmg tambien funciona con el
    // voy a escribir un cuanto codigo al respecto, arriba estare usando el SceneManagement tambien ;P

    public float life = 1000f;

    public void receiveAttack(float lessLife)
    {
        life -= lessLife;
       // print("Life = " + life);

        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Final_Cinematic");
        }

    }


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
            transform.position = Vector3.Lerp(posicionInicial, new Vector3(puntoB.position.x, transform.position.y, transform.position.z), t);

            // Actualizar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null; // Esperar hasta el próximo frame
        }

        // Asegurarse de que el objeto esté en el punto B al final
       // transform.position = puntoB.position;
        enMovimiento = false;

        print("Attack");
        animator.SetBool("Attack", true);
        StartCoroutine(waitToAttack());
    }


    IEnumerator waitToAttack()
    {

        yield return new WaitForSeconds(1.7f);

        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
            manager.hormigasObreras.Remove(hormigaObrera);
            Destroy(hormigaObrera);
        }
            StartCoroutine(Boss());
    }

    public void AttackBoss()
    {
        print("Ataque");
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
        else
        {
            lifeoftheboss -= 10;

            if( lifeoftheboss <= 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(4);
            }
        }
    }
}


