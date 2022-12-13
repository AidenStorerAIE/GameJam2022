using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 startPoint;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startPoint = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - startPoint);
            Vector3 move = new Vector3(pos.x * -dragSpeed, 0, 0);

            transform.Translate(move, Space.World);
        }

    }


}