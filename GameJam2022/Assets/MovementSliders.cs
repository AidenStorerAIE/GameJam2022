using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSliders : MonoBehaviour
{
    public Slider sliderMS;
    public Slider sliderJS;
    public Slider sliderGS;
    public Slider sliderHS;
    public PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
        _playerMovement = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        sliderMS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderJS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderGS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderHS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        /*sliderMS.minValue = 0;
        sliderMS.maxValue = 100;*/
    }
    public void ValueChangeCheck()
    {
      /*  Debug.Log("JS = " + sliderJS.value);
        Debug.Log("MS = " + sliderMS.value);
        Debug.Log("GS = " + sliderGS.value);
        Debug.Log("HS = " + sliderHS.value);*/
        _playerMovement.mSliderValue = sliderMS.value;
        _playerMovement.jSliderValue = sliderJS.value;
        _playerMovement.hSliderValue = sliderHS.value;
        _playerMovement.gSliderValue = sliderGS.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
