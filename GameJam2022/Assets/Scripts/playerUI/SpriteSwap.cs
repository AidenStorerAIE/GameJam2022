using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwap : MonoBehaviour
{
    Image image;
    public List<Sprite> clocks;
    public float slowMoTimeScale;
    public float startTimeScale;
    public float startFixedDeltaTime;
    public bool On = false;
    // Start is called before the first frame update
    void Start()
    {
        startFixedDeltaTime = Time.fixedDeltaTime;
        startTimeScale = Time.timeScale;
        image = GetComponent<Image>();
    }

    public void toggle(bool ON)
    {
        if(ON == true) { 
            image.sprite = clocks[1];
            StartSlowMo();
        }
        if(ON == false)
        {
            image.sprite =clocks[0];
            StopSlowMo();
        }
    }

  public void StartSlowMo()
    {
            
        Time.timeScale = slowMoTimeScale;
        Time.fixedDeltaTime = startTimeScale*slowMoTimeScale;
    }
    public void StopSlowMo()
    {
            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime;

    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
