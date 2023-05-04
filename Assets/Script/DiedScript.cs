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
    public GameObject mc;
    public GameObject QuestMenu;

    // Start is called before the first frame update
    void Start()
    {
        //causeOfDeathText = GetComponent<TMP_Text>();
        canMove = true;
        respawnButton.SetActive(false);
        causeOfDeathText.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hp.alive)
        {
            causeOfDeathText.text = hp.causeOfDeath;
            darkScreen.SetActive(true);
            canMove = false;
            respawnButton.SetActive(true);
            causeOfDeathText.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().Pause();
        }
        else if(hp.alive && QuestMenu.activeInHierarchy == false)
        {
            darkScreen.SetActive(false);
            canMove = true;
            causeOfDeathText.gameObject.SetActive(false);
            respawnButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().UnPause();
            
        }
        else
        {
            darkScreen.SetActive(false);
            canMove = true;
            causeOfDeathText.gameObject.SetActive(false);
            respawnButton.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().UnPause();
        }
    }

    public void ButtonPressed()
    {
        canMove = true;
        respawnButton.SetActive(false);
        causeOfDeathText.gameObject.SetActive(false);
        hp.currentHP = hp.maxHP;
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerMovement>().enabled = true;
        mc.GetComponent<CameraController>().enabled = true;
    }
}
