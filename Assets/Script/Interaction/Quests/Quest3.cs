using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest3 : MonoBehaviour
{
    static int Items;
    public TMP_Text Itemtext;
    public bool enabled;
    public Button Quest3Button;

    public Slider Slider;
    public int maxItems = 3;
    public GameObject PickupBar;
    public Image img3;
    public GameObject QComplete;
    void Start()
    {
        Itemtext.gameObject.SetActive(false);
        enabled = false;
        SetMaxItems(maxItems);
        Slider.value = 0;
    }
    void Update()
    {
        if(enabled){
            PickupBar.gameObject.SetActive(true);
            Itemtext.gameObject.SetActive(true);
            Itemtext.text = "Items: " + Items + "/ 3";
            SetItems(Items);
            if(Items == maxItems){
                StartCoroutine(Complete());
                enabled = false;
                PickupBar.SetActive(false);
                img3.color = Color.green;
            }
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public static void Item(){
        Items++;
    }
    public void ActivateQuest(){
        enabled = true;
    }
    public void SetMaxItems(int Item){
        Slider.maxValue = Item;
    }
    public void SetItems(int Item){
        Slider.value = Item;
    }
    IEnumerator Complete(){
        QComplete.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        QComplete.gameObject.SetActive(false);
    }
}
