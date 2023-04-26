using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if((other.tag == "Sword")){
            TakeDamage(10);
            Debug.Log(currentHealth);
        }
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        if(currentHealth <= 0){
            Quest2.Kills();
            Destroy(gameObject);
        }
    }
}
