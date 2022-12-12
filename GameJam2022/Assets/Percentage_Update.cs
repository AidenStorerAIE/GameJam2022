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
        tag = _percentageText.tag;
        switch(tag)
        {
            case "Health":
                _percentageText.text = Mathf.RoundToInt(value)+"";
                break;
            case "Move":
                _percentageText.text = Mathf.RoundToInt(value) + "";
                break;
            case "Jump":
                _percentageText.text = Mathf.RoundToInt(value) + "";
                break;
            case "Hang":
                _percentageText.text = value.ToString("F2") + "s";
                break;
            case "AD":
                _percentageText.text = Mathf.RoundToInt(value) + "";
                break;
            case "Gravity":
                _percentageText.text = Mathf.RoundToInt(value) + "";
                break;
        }
        
        }
        
    }

