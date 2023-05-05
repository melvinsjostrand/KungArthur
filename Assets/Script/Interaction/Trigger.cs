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
    public GameObject mc;
    public DialogueSystem DS;
    public bool DActive; //kollar om player pratar med npc och sätter denna true så att dialogsystemet kan funka
    void Start(){
        DActive = false;
    }
    void Update()
    {
        if((istriggeringnpc) && (Input.GetKeyDown(KeyCode.E))){ //npc dialog
                DS.gameObject.SetActive(true);
                DS.Active();
                npcText.gameObject.SetActive(false);

        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "NPC"){
            istriggeringnpc = true;
            triggeringNPC = other.gameObject;
            npcText.gameObject.SetActive(true);
                Cursor.visible = true;
        }
        if(other.tag == "Coin"){
            Quest1.Points();
            Destroy(other.gameObject);
        }
        if (other.tag == "PickupItem")
        {
            Quest3.Item();
            Destroy(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other) {
        npcText.gameObject.SetActive(false);
        QuestMenu.SetActive(false);
        istriggeringnpc = false;
        triggeringNPC = null;
        mc.GetComponent<CameraController>().enabled = true;
    }
}