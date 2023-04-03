//skriven av hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
    static int points;
    public TMP_Text Coin;
    public bool enabled;
    public Button Quest1Button;

    public Slider Slider;
    public int maxPoints = 20;
    public GameObject PointsBar;
    public Image img;
    void Start()
    {
        Coin.gameObject.SetActive(false);
        enabled = false;
        SetMaxPoints(maxPoints);
        Slider.value = 0;
    }

    void Update()
    {
        if(enabled){
            PointsBar.gameObject.SetActive(true);
            Coin.gameObject.SetActive(true);
            Coin.text = "Points: "+ points + "/ 20";
            SetPoint(points);
            if(points == maxPoints){
            enabled = false;
            PointsBar.SetActive(false);
            img.color = Color.green;
            } 
        }    
    }

    public static void Points(){
        points++;
    }
    public void ActivateQuest(){
        enabled = true;
    }

    public void SetMaxPoints(int point){
        Slider.maxValue = point;
    }
    public void SetPoint(int point){
        Slider.value = point;
    }
}
