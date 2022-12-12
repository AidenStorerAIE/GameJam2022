using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    Slider sliderMS;
    public PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        sliderMS = GetComponent<Slider>();
        _playerMovement = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        sliderMS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        /*sliderMS.minValue = 0;
        sliderMS.maxValue = 100;*/
    }
    public void ValueChangeCheck()
    {
        Debug.Log(sliderMS.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
