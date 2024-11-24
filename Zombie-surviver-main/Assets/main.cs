using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    GameObject Z1;
    Animator Zani;
   
    // Start is called before the first frame update
    void Start()
    {
        Z1 = GameObject.FindGameObjectWithTag("Zombie");
        
        Zani = Z1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Zani.SetTrigger("fall");
            Debug.Log("keywaspressed");
        }
        if (Input.GetKeyDown("2"))
            Zani.SetTrigger("idle");

    }
}
