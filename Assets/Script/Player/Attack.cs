using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Sword;
    public BoxCollider Collider;
    void Start()
    {
        Collider.GetComponent<BoxCollider>().enabled = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(SwordSwing());
        }
    }
    IEnumerator SwordSwing(){
        Collider.enabled = true;
        Sword.GetComponent<Animator>().Play("AttackAnimation");
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("New State");
        Collider.enabled = false;
    }
}
