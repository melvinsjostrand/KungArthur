using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HP : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume volume;
    [SerializeField]private Vignette vignette;
    public int maxHP = 100;
    public int currentHP;
    public bool alive;
    public string causeOfDeath;
    

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        currentHP = maxHP;

        vignette = volume.sharedProfile.GetSetting<Vignette>(); 
    }

    // Update is called once per frame
    void Update()
    {
        FloatParameter f = new FloatParameter();
        if (currentHP <= 30)
        {
            f.value = 0.42f;
            vignette.intensity.value = f;
        }
        else if (currentHP <= 32)
        {
            f.value = 0.35f;
            vignette.intensity.value = f;
        }
        else if (currentHP <= 34)
        {
            f.value = 0.28f;
            vignette.intensity.value = f;
        }
        else if (currentHP <= 36)
        {
            f.value = 0.21f;
            vignette.intensity.value = f;
        }
        else if (currentHP <= 38)
        {
            f.value = 0.14f;
            vignette.intensity.value = f;
        }
        else if (currentHP <= 40)
        {
            f.value = 0.07f;
            vignette.intensity.value = f;
        }
        else
        {
            f.value = 0f;
            vignette.intensity.value = f;
        }

        if (currentHP <= 0)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }

        if (alive == false)
        {
            //print(causeOfDeath);

        }

    }

    public void TakeDamage(int damage)
        {
            currentHP -= damage;
        }
}
