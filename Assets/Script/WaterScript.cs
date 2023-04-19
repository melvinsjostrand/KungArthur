using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour 
{

    public HP hp;
    public string drunknade = "Du drunknade =(";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            var healthComponent = collision.GetComponent<HP>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(100);
                hp.causeOfDeath = drunknade;
            }
        }
    }
}
