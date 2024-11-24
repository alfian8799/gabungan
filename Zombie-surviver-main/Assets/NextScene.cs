using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    PlayerC player;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player") {
            Debug.Log("nextlevel");
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
