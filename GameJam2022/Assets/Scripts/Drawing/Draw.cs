using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public ColorPicker colorPicker;
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
    }

    void Drawing()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < -2 || mousePos.x > 6 || mousePos.y < -3 || mousePos.y > 5)
        {
            check = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && mousePos.x > -2 && mousePos.x < 6 && mousePos.y > -3 && mousePos.y < 5)
        {
            check = true;
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0) && mousePos.x > -2 && mousePos.x < 6 && mousePos.y > -3 && mousePos.y < 5 && check == true)
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > -2 && mousePos.x < 6 && mousePos.y > -3 && mousePos.y < 5)
        {
            GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
            currentLineRenderer.SetPosition(0, mousePos);
            currentLineRenderer.SetPosition(1, mousePos);
        }

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
        if (lastPos != mousePos && mousePos.x > - 2 && mousePos.x < 6 && mousePos.y > -3 && mousePos.y < 5)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

}