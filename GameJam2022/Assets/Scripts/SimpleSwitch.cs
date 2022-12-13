using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitch : MonoBehaviour
{
    public GameObject playCamera;
    public GameObject buildCamera;
    public GameObject editor;
    public GameObject cardBoard;
    public GameObject blockPreviews;
    public GameObject menu;
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
            menu.SetActive(false);
            blockPreviews.SetActive(true);
            cardBoard.SetActive(true);
            buildCamera.SetActive(true);
            editor.SetActive(true);
            Time.timeScale = 0;
            editing = false;
        }
        else if (!editing)
        {
            playCamera.SetActive(true);
            menu.SetActive(true);
            blockPreviews.SetActive(false);
            buildCamera.SetActive(false);
            cardBoard.SetActive(false);
            editor.SetActive(false);
            Time.timeScale = 1;
            editing = true;
        }
    }
}
