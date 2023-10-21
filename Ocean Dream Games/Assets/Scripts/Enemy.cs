using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private GameObject hormigaObrera;
    private HormigaObrera hormiga;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float velocity;
    [SerializeField] private float attack;
    [SerializeField] private float timeAttack;
    // Start is called before the first frame update
    void Start()
    {
        hormigaObrera = gameManager.hormigasObreras[UnityEngine.Random.Range(0, gameManager.hormigasObreras.Count)];
        target = hormigaObrera.transform;
        hormiga = hormigaObrera.GetComponent<HormigaObrera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hormigaObrera != null)
        {
            float step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y + 0.7f, target.position.z), step);
        
            if(timeAttack > 1)
            {
                timeAttack -= Time.deltaTime;
            }
            else if(Vector3.Distance(transform.position, target.position) < 1 )
            {
                print("Attack");
                hormiga.receiveAttack(attack);
                if(hormiga.life <= 0)
                {
                    gameManager.hormigasObreras.Remove(hormigaObrera);
                    Destroy(hormigaObrera);
                    selectNewHormiga();
                }
                timeAttack = 5;
            }
        }
        
    }

    public void selectNewHormiga()
    {
        if(hormigaObrera != null)
        {
            hormigaObrera = gameManager.hormigasObreras[UnityEngine.Random.Range(0, gameManager.hormigasObreras.Count)];
            target = hormigaObrera.transform;
            hormiga = hormigaObrera.GetComponent<HormigaObrera>();

        }
    }

}
