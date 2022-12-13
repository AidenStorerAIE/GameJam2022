using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationplayback : MonoBehaviour
{
    AudioManager aM;  
    // Start is called before the first frame update
    void Start()
    {
        aM = GameObject.FindObjectOfType<AudioManager>();
        aM.PlayUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
