//skriven av hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest2 : MonoBehaviour
{
    public bool enabled;
    public Button Quest2Button;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateQuest(){
        enabled = true;
    }
}
