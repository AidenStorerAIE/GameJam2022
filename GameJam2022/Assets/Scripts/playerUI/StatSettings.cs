using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sliderH;
    public Slider sliderStomp;
    public PlayerMovement pM;
    public Health H;
    void Start()
    {
        pM = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        
        sliderH.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderStomp.onValueChanged.AddListener(delegate { ValueChangeCheck();});
/*        sliderAD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderDD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });*/
    }
    public void ValueChangeCheck()
    {
        Debug.Log("JS = " + sliderH.value);


        H.healthSliderValue = sliderH.value;
        pM.stompSliderValue = sliderStomp.value;



        // Update is called once per frame
    }
        void Update()
        {

        }
}
