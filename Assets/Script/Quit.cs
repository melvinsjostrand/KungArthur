using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void quit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}