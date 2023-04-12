using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
   // private Volume volume;
    public int maxHP = 100;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        //volume = GetComponent<Volume>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if(currentHP <= 40)
       // {
          //  vignette.intencity = 0.5;
       // }
        //else
      //  {
     //       vignette.intencity = 0;
       // }
    }
}
