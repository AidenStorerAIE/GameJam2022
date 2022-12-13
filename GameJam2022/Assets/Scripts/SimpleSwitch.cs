using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitch : MonoBehaviour
{
    public GameObject playCamera;
    public GameObject buildCamera;
    public GameObject editor;
    public bool editing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        if (editing)
        {
            playCamera.SetActive(false);
            buildCamera.SetActive(true);
            editor.SetActive(true);
            editing = false;
        }
        else if (!editing)
        {
            playCamera.SetActive(true);
            buildCamera.SetActive(false);
            editor.SetActive(false);
            editing = true;
        }
    }
}
