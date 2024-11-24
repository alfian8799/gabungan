using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class HealthPack : MonoBehaviour
{
 //public AudioClip HSound;
    
    private AudioSource HealthSound;
    private bool IsActive = true;

    PlayerC Player;
    public int healV = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (IsActive == true)
        {
            
            Player.heal(healV);

            HealthSound.Play();

            IsActive = false;


            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
        
       // transform.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC>();
        HealthSound = GetComponent<AudioSource>();
        //HealthSound.clip = HSound;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 50 * Time.deltaTime);
    }
}
