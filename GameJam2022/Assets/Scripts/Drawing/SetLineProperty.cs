using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLineProperty : MonoBehaviour
{
    public ColorPicker colorPicker;
    public Slider slider;
    public LineManager lineManager;
    public Draw draw;
    private Gradient gradient;
    private GradientColorKey[] gck = new GradientColorKey[2];
    private GradientAlphaKey[] gak = new GradientAlphaKey[2];

    // Start is called before the first frame update
    void Awake()
    {
            draw = FindObjectOfType<Draw>();
        if (draw != null)
        {
            transform.parent = draw.currentCanvas.transform;
            slider = FindObjectOfType<Slider>();
            colorPicker = FindObjectOfType<ColorPicker>();
            lineManager = FindObjectOfType<LineManager>();
            GetComponent<LineRenderer>().sortingOrder = lineManager.layerCount;
            lineManager.layerCount += 1;
            gradient = new Gradient();
            gck[0].color = colorPicker.SelectedColor;
            gck[1].color = colorPicker.SelectedColor;
            gak[0].alpha = 255;
            gak[1].alpha = 255;
            gradient.SetKeys(gck, gak);
            GetComponent<LineRenderer>().SetWidth(slider.value / 10, slider.value / 10);
            GetComponent<LineRenderer>().colorGradient = gradient;
            lineManager.lines.Add(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
