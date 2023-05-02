using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool IsActive = false;
    public GameObject QuestMenu;
    [SerializeField] private int index;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine(){
        foreach( char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine(){
        if(index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            QuestMenu.SetActive(true);
            gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Active(){
        IsActive = true;
        gameObject.SetActive(true);
        textComponent.gameObject.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }
}
