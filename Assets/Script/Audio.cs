using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource AudioSource;
    private float Volume = 100f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame

    public void updateVolume(float volume){
        Volume = volume;
    }
}
