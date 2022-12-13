using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sliderH;
    public Slider sliderD;
    public Slider sliderAS;
    public EnemyEditor EE;
    public EnemyHealth EH;
    public GameObject enemy;
    void Start()
    {
        EE = GameObject.FindObjectOfType<EnemyEditor>().GetComponent<EnemyEditor>();
        enemy = EE.enemy.gameObject;
        sliderH.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderAS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        Debug.Log("JS = " + sliderH.value);


        EH.healthSliderValue = sliderH.value;


        // Update is called once per frame
    }
    void Update()
    {

    }
}