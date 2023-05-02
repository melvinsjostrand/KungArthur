//script skriven av hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab; //detta säger till vilket objekt som ska skapas
    public GameObject coin;

    public GameObject enemy;
    public GameObject enemyPrefab;

    public GameObject item;

    public Quest1 quest1;
    public Quest2 quest2;
    public Quest3 quest3;
    void Start()
    {
        
    }
    void Update()
    {
        if(quest1 == null) return;
        if(quest1.enabled){
            if(coin == null){ //skapar en coin i en slumpmässig position
                coin = Instantiate(coinPrefab);
                Vector3 position = Vector3.one;
                position.x = Random.Range(49f, 75f);
                position.z = Random.Range(192f, 215f);
                position.z = 46f;
                coin.transform.position = position;
            }
        }
        if(quest2 == null) return;
        if(quest2.enabled){
            if(enemy == null){ //skapar en fiende i en slumpmässig position
                for (int i = 0; i < 3; i++)
                {
                enemy = Instantiate(enemyPrefab);
                Vector3 position = Vector3.one;
                position.x = Random.Range(-13f, 13f);
                position.z = Random.Range(-13f, 13f);
                enemy.transform.position = position;
                i++;
                }
            }
        }
        if(quest3 == null) return;
        if(quest3.enabled){
            item.gameObject.SetActive(true);
        }
    }
}
