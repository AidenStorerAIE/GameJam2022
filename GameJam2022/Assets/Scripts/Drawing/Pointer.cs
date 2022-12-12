using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public Camera m_camera;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(m_camera.ScreenToWorldPoint(Input.mousePosition).x, m_camera.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.GetChild(0).localScale = new Vector3 (slider.GetComponent<Slider>().value, slider.GetComponent<Slider>().value, slider.GetComponent<Slider>().value);
    }
}
