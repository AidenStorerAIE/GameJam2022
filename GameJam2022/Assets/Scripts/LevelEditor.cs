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
    public List<GameObject> blocks;
    private Vector3 posToCheck;
    private bool topCheck;
    private bool leftCheck;
    private bool rightCheck;
    public GameObject terrainParent;

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
            blockDestroyed = false;
            GameObject newBlock = Instantiate(permaBlock, tempBlockLocation, Quaternion.identity);
            newBlock.transform.SetParent (terrainParent.transform);
            if (blockLocations.Count > 0)
            {
                foreach (var block in blocks)
                {
                    if (tempBlock.transform.position == block.transform.position)
                    {
                        Debug.Log("SpaceOccupied");
                        Destroy (newBlock);
                        blockDestroyed = true;
                    }
                }
                if (blockDestroyed != true)
                {
                    blockLocations.Add(newBlock.transform.position);
                    blocks.Add(newBlock);
                    UpdateBlocks();
                }
            }
            else
            {
                blockLocations.Add(newBlock.transform.position);
                blocks.Add(newBlock);
                UpdateBlocks();
            }

        }
    }
    void UpdateBlocks()
    {
        foreach (var block in blocks)
        {
            posToCheck = new Vector3(block.transform.position.x, block.transform.position.y + 1, block.transform.position.z);
            if (blockLocations.Contains(posToCheck))
            {
                topCheck = true;
            }
            else
            {
                topCheck = false;
            }
            posToCheck = new Vector3(block.transform.position.x + 1, block.transform.position.y, block.transform.position.z);
            if (blockLocations.Contains(posToCheck))
            {
                rightCheck = true;
            }
            else
            {
                rightCheck = false;
            }
            posToCheck = new Vector3(block.transform.position.x - 1, block.transform.position.y, block.transform.position.z);
            if (blockLocations.Contains(posToCheck))
            {
                leftCheck = true;
            }
            else
            {
                leftCheck = false;
            }
            if (topCheck && leftCheck && rightCheck)
            {
                block.GetComponent<BlockChangeScript>().Bottom();
            }
            if (!topCheck && leftCheck && rightCheck)
            {
                block.GetComponent<BlockChangeScript>().Top();
            }
            if (topCheck && !leftCheck && rightCheck)
            {
                block.GetComponent<BlockChangeScript>().BottomRight();
            }
            if (topCheck && leftCheck && !rightCheck)
            {
                block.GetComponent<BlockChangeScript>().BottomLeft();
            }
            if (!topCheck && !leftCheck && rightCheck)
            {
                block.GetComponent<BlockChangeScript>().Left();
            }
            if (!topCheck && leftCheck && !rightCheck)
            {
                block.GetComponent<BlockChangeScript>().Right();
            }
            if (!topCheck && !leftCheck && !rightCheck)
            {
                block.GetComponent<BlockChangeScript>().Center();
            }
            if (topCheck && !leftCheck && !rightCheck)
            {
                block.GetComponent<BlockChangeScript>().BottomCenter();
            }
        }
    }
}
