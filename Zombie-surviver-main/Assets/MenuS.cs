using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuS : MonoBehaviour
{
    public void OnStartPress()
    {
        SceneManager.LoadScene("scene 7");
    }
    public void OnCreditsPress()
    {
        SceneManager.LoadScene("credits");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
