using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public List<GameObject> hormigasObreras;

    public List<GameObject> actualizarLista;
    //Etapas
    public bool hormigasPerdidas;
    public bool enemyFights;
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

    //Boos Active 
    [SerializeField] private Transform targetBossStart;
    [SerializeField] private GameObject bossOB;

    public float cronometro;

    public float countNull;
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
        foreach(GameObject go in hormigasObreras)
        {
            if(go == null)
            {
                hormigasObreras.Remove(go);
            }
        }
        //print(cronometro += Time.deltaTime); 
        float vidasTotales = hormigasObreras.Count-countNull; 
        vidasUI.text = vidasTotales.ToString();
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
                timeAntLost = Random.Range(1,3);
            }
        }
        
        if(targetBossStart.position.x >= 35)
        {
            print("Inicia Boss");
            bossOB.SetActive(true);
            bossFight = true;
        }

        if(hormigasObreras.Count < 1)
        {

            SceneManager.LoadScene(5);
        }

        
    }


}
