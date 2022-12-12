using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percentage_Update : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _percentageText;
    void Start()
    {
        _percentageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextUpdate(float value)
    {
        _percentageText.text = Mathf.RoundToInt(value*100)+"%";
    }
}
