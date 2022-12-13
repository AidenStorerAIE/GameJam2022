using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public Texture2D pointCursor;
    public int i;
    private Vector2 cursorHotSpot;
    public Slider slider;
    public Camera m_camera;
    public Vector2 cursorPosition;
    private bool check;
    void Start()
    {
        UpdateCursor();
    }
    private void Update()
    {
        cursorPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (i != slider.value)
        {
            i = (int)slider.value;
        }
        if (cursorPosition.x < -2f && check == true)
        {
            UpdateToPointCursor();
            check = false;
        }
        if (cursorPosition.x >= -2f && check == false)
        {
            UpdateCursor();
            check = true;
        }
    }
    void UpdateCursor()
    {
        cursorHotSpot = new Vector2(cursorTexture[i - 1].width / 2, cursorTexture[i - 1].height / 2);
        Cursor.SetCursor(cursorTexture[i - 1], cursorHotSpot, CursorMode.ForceSoftware);
    }

    void UpdateToPointCursor()
    {
        cursorHotSpot = new Vector2(pointCursor.width / 2, pointCursor.height / 2);
        Cursor.SetCursor(pointCursor, cursorHotSpot, CursorMode.ForceSoftware);
    }
}