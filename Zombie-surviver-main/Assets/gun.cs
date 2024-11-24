using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointsFree;
public class gun : MonoBehaviour
{
    public Camera main_cam;
    GameObject Z1;
    GameObject Z2;
    Animator Zani;
    Animator Zani2;
    WaypointsTraveler Wscript;
    Collider Z2c;
    Zombie_AI AiScript;
    Boss BossScript;

    public int counter = 9999;
   
    // Start is called before the first frame update
    void Start()
    {
       
        Z2 = GameObject.Find("Zombie2");
        Zani2 = Z2.GetComponent<Animator>();

        Wscript = Z2.GetComponent<WaypointsTraveler>();
        Z2c = Z2.GetComponent<CapsuleCollider>();
    }
    void shoot()
    {
        //Debug.Log("??");
        counter = counter - 1;
        RaycastHit hit;
        if (Physics.Raycast(main_cam.transform.position,main_cam.transform.forward,out hit))
        {
            Debug.Log(hit.transform.tag);

            if (hit.transform.tag == "Zombie")
            {
                AiScript = hit.transform.gameObject.GetComponent<Zombie_AI>();
                AiScript.Shot();
            }
            if (hit.transform.tag == "Boss")
            {
                BossScript = hit.transform.gameObject.GetComponent<Boss>();
                BossScript.Shot();
            }
           
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            
        }
        
    }
}
