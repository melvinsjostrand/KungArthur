using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiedScript : MonoBehaviour
{

    public GameObject darkScreen;
    public GameObject respawnButton;
    public HP hp;
    public TMP_Text causeOfDeathText;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        causeOfDeathText = GetComponent<TMP_Text>();
        canMove = true;
        respawnButton.SetActive(false);
        causeOfDeathText.gameObject.SetActive(false);
        causeOfDeathText.text = hp.causeOfDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.alive == false)
        {
            darkScreen.SetActive(true);
            canMove = false;
            respawnButton.SetActive(true);
            causeOfDeathText.gameObject.SetActive(true);
        }
        else
        {
            darkScreen.SetActive(false);
            canMove = true;
        }
    }
}
