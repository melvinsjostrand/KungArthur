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
    public Transform spawnPoint;

    public bool canMove;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //causeOfDeathText = GetComponent<TMP_Text>();
        canMove = true;
        respawnButton.SetActive(false);
        causeOfDeathText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.alive == false)
        {
            causeOfDeathText.text = hp.causeOfDeath;
            darkScreen.SetActive(true);
            canMove = false;
            respawnButton.SetActive(true);
            causeOfDeathText.gameObject.SetActive(true);
        }
        else
        {
            darkScreen.SetActive(false);
            canMove = true;
            causeOfDeathText.gameObject.SetActive(false);
        }
    }

    public void ButtonPressed()
    {
        canMove = true;
        respawnButton.SetActive(false);
        causeOfDeathText.gameObject.SetActive(false);
        hp.currentHP = hp.maxHP;
        transform.position = spawnPoint.position;
    }
}
