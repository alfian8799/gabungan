using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerC : MonoBehaviour
{
    public GameObject DamI;
    bool IsHit = false;
    public ProgressBar ProBar;
    public GameObject GameOver;



    public void hit()
    {
        Debug.Log("player hit");
        var colour = DamI.GetComponent<Image>().color;
        colour.a = 1f;
        DamI.GetComponent<Image>().color = colour;
        IsHit = true;

        ProBar.BarValue -= 10;
        if (ProBar.BarValue == 0)
        {
            GameOver.SetActive(true);
            colour = DamI.GetComponent<Image>().color;
            colour.a = 1f;
            DamI.GetComponent<Image>().color = colour;
            IsHit = false;

        }
    }

    public void heal(int HealVal)
    {
        ProBar.BarValue += HealVal;
    }
   
  
    // Start is called before the first frame update
    void Start()
    {
        ProBar.BarValue = 100;
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHit == true)
        {
            if (DamI.GetComponent<Image>().color.a > 0)
            {

                var colour = DamI.GetComponent<Image>().color;
                colour.a -= 0.01f;
                DamI.GetComponent<Image>().color = colour;
            }
            else
            {
                IsHit = false;
            }
        }
    }
}
