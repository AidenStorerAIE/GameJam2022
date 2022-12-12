using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sliderH;
    /*public Slider sliderAD;
    public Slider sliderDD;*/
    public PlayerMovement pM;
    public Player P;
    void Start()
    {
        pM = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        P = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        sliderH.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
/*        sliderAD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderDD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });*/
    }
    public void ValueChangeCheck()
    {
        Debug.Log("JS = " + sliderH.value);


        P.healthSliderValue = sliderH.value;


        // Update is called once per frame
    }
        void Update()
        {

        }
}
