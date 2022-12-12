using UnityEngine;
using System.Collections.Generic;

public class Draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public ColorPicker colorPicker;
    public List<GameObject> canvases;
    public GameObject currentCanvas;
    public bool check;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    public void Start()
    {
        colorPicker = FindObjectOfType<ColorPicker>();
    }

    public void Update()
    {
        Drawing();
        foreach (var c in canvases)
        {
            if (c.GetComponent<CanvasScript>().isEnabled)
            {
                currentCanvas = c;
            }
            else
            {
                currentCanvas = null;
            }
        }
    }

    void Drawing()
    {
        foreach (GameObject canvas in canvases)
        {
            if (canvas.GetComponent<CanvasScript>().isEnabled == false)
            {
                check = false;
            }
            if (canvas.GetComponent<CanvasScript>().isEnabled == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    check = true;
                    CreateBrush();
                }
                else if (Input.GetKey(KeyCode.Mouse0) && check == true)
                {
                    PointToMousePos();
                }
                else
                {
                    currentLineRenderer = null;
                }
            }
        }
    }

    void CreateBrush()
    {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
            currentLineRenderer.SetPosition(0, mousePos);
            currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint(Vector2 pointPos)
    {
            currentLineRenderer.positionCount++;
            int positionIndex = currentLineRenderer.positionCount - 1;
            currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

}