using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> hormigasObreras;
    public bool bossFight;

    //Time ramdon to lost the ant
    [SerializeField] float timeAntLost;
    float probably;
    int ejectOnce = 1;

    //Time of the boss
    float timeBossWait = 60;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Transform enemySpawn;

    //UI
    [SerializeField] private TextMeshProUGUI vidasUI;

    public float cronometro;
    // Start is called before the first frame update
    void Start()
    {
        bossFight = false;
        probably = 10;
        timeAntLost = Random.Range(3, 7);
        vidasUI.text = hormigasObreras.Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        vidasUI.text = hormigasObreras.Count.ToString();
        if(!bossFight)
        {
            if (timeAntLost > 0)
            {
                timeAntLost -= Time.deltaTime;
            }
            else
            {
                int probablyEnter = Random.Range(0, 11);
                print("Probably = " + probablyEnter);
                if (probablyEnter <= probably)
                {
                    hormigasObreras[Random.Range(0, hormigasObreras.Count)].GetComponent<HormigaObrera>().StartCorrutina();
                    if(ejectOnce == 0)
                    {
                        probably = 4;
                        ejectOnce++;
                    }
                }
                timeAntLost = Random.Range(10, 15);
            }
        }
        

        
    }


}
