using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    public GameObject enemy;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time-= Time.deltaTime;
        }
        else
        {
            int r = Random.Range(0, 2);
            if(r==0)
            {

                Instantiate(enemy, new Vector3(target1.position.x + 10, 0,0), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, new Vector3(target1.position.x - 10, 0, 0), Quaternion.identity);
            }
            time = 10;
        }
    }
}
