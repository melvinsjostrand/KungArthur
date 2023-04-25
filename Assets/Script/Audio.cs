using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public GameObject ObjectMusic;
    public Slider volumeSlider;
    private AudioSource AudioSource;
   

    private float Volume = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        Volume = PlayerPrefs.GetFloat("volume");

        AudioSource.volume = Volume;
        volumeSlider.value = Volume;
    }

    // Update is called once per frame
    private void Update() 
        {
            AudioSource.volume = Volume;
            PlayerPrefs.SetFloat("volume", Volume);
        }
    

    public void updateVolume(float volume){
        Volume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;    
    
    }
}
