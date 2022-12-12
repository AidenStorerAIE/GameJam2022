using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public Vector2 cursorPosition;
    public Vector2 cursorPositionRounded;
    public Vector2 lastCursorPositionRounded;
    public Camera m_camera;
    public GameObject tempBlock;
    public GameObject permaBlock;
    public Vector3 tempBlockLocation;
    public bool blockDestroyed;
    public List<Vector3> blockLocations;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempBlockLocation = tempBlock.transform.position;
        cursorPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
        cursorPositionRounded = new Vector2 (Mathf.Round(cursorPosition.x), Mathf.Round(cursorPosition.y));
        if (lastCursorPositionRounded != cursorPositionRounded)
        {
            tempBlock.transform.position = new Vector3 (cursorPositionRounded.x, cursorPositionRounded.y, 0);
            lastCursorPositionRounded = cursorPositionRounded;
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlock = Instantiate(permaBlock, tempBlockLocation, Quaternion.identity);
            newBlock.transform.SetParent (this.transform);
            if (blockLocations.Count > 0)
            {
                foreach (var block in blockLocations)
                {
                    if (tempBlock.transform.position == block)
                    {
                        Debug.Log("SpaceOccupied");
                        Destroy (newBlock);
                        blockDestroyed = true;
                    }
                }
                if (blockDestroyed != true)
                {
                    blockLocations.Add(newBlock.transform.position);
                }
            }
            else
            {
                blockLocations.Add(newBlock.transform.position);
            }

        }
    }
}
