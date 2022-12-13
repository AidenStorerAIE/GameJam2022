using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Slider speed;
    public Slider jump;
    public GameObject build;
    // Start is called before the first frame update
    void Start()
    {
        speed.maxValue = 6;
        jump.maxValue = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
