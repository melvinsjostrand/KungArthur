//script skriven av hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour 
{
    private GameObject triggeringNPC; //npc
    private bool istriggeringnpc; //npc
    public TMP_Text npcText;
    public GameObject QuestMenu;
    void Update()
    {
        if(istriggeringnpc){ //npc dialog
            if(Input.GetKeyDown(KeyCode.E)){
                QuestMenu.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "NPC"){
            istriggeringnpc = true;
            triggeringNPC = other.gameObject;
            npcText.gameObject.SetActive(true);
        }
        if(other.tag == "Coin"){
            Quest1.Points();
            Destroy(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other) {
        npcText.text = "Press E to talk";
        npcText.gameObject.SetActive(false);
        QuestMenu.SetActive(false);
        istriggeringnpc = false;
        triggeringNPC = null;
    }
}
