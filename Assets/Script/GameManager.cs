//script skriven av hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject coin;
    public Quest1 quest1;
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
                position.x = Random.Range(-13f, 13f);
                position.z = Random.Range(-13f, 13f);
                coin.transform.position = position;
            }
        }
    }
}
