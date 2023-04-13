using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HP : MonoBehaviour
{
    private PostProcessVolume volume;
    public Vignette vignette;
    public int maxHP = 100;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        currentHP = maxHP;
        vignette = GetComponent<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatParameter f = new FloatParameter();
        if (currentHP <= 40)
        {
            f.value = 0.5f;
            vignette.intensity = f;
        }
        else
        {
            f.value = 0;
            vignette.intensity = f;
        }
    }
}
