using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public Vector2 cursorPosition;
    public Vector2 cursorPositionRounded;
    public Vector2 lastCursorPositionRounded;
    public Vector2 lastCursorPositionRoundedForBlockPlacing;
    public Camera m_camera;
    public GameObject tempBlock;
    public List<GameObject> permaBlock;
    public Vector3 tempBlockLocation;
    public bool blockDestroyed;
    public List<Vector3> blockLocations;
    public List<GameObject> blocks;
    public List<Vector3> decorLocations;
    private Vector3 posToCheck;
    private bool topCheck;
    private bool leftCheck;
    private bool rightCheck;
    public GameObject terrainParent;
    public int tBD;
    public bool destroy;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && i < permaBlock.Count - 1)
        {
            i++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && i > 0)
        {
            i--;
        }
        tempBlockLocation = tempBlock.transform.position;
        cursorPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (cursorPosition.x < -2)
        {
            tempBlock.SetActive(false);
        }
        else
        {
            tempBlock.SetActive(true);
            cursorPositionRounded = new Vector2(Mathf.Round(cursorPosition.x), Mathf.Round(cursorPosition.y));
            if (lastCursorPositionRounded != cursorPositionRounded)
            {
                tempBlock.transform.position = new Vector3(cursorPositionRounded.x, cursorPositionRounded.y, 0);
                lastCursorPositionRounded = cursorPositionRounded;
            }
            if (Input.GetMouseButton(0) && lastCursorPositionRoundedForBlockPlacing != cursorPosition)
            {
                lastCursorPositionRoundedForBlockPlacing = cursorPositionRounded;
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    foreach (var block in blocks)
                    {
                        if (tempBlock.transform.position == block.transform.position)
                        {
                            destroy = true;
                            tBD = blocks.IndexOf(block);
                        }
                    }
                }
                else
                {
                    blockDestroyed = false;
                    GameObject newBlock = Instantiate(permaBlock[i], cursorPositionRounded, Quaternion.identity);
                    newBlock.transform.SetParent(terrainParent.transform);
                    if (blockLocations.Count > 0)
                    {
                        destroy = false;
                        foreach (var block in blocks)
                        {
                            if (tempBlock.transform.position == block.transform.position)
                            {
                                Debug.Log("SpaceOccupied");
                                Destroy(newBlock);
                                blockDestroyed = true;
                            }
                        }
                        if (blockDestroyed != true)
                        {
                            if (i == 0)
                            {
                                blocks.Add(newBlock);
                                blockLocations.Add(newBlock.transform.position);
                            }
                            else
                            {
                                blocks.Add(newBlock);
                                decorLocations.Add(newBlock.transform.position);
                            }
                            UpdateBlocks();
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            blocks.Add(newBlock);
                            blockLocations.Add(newBlock.transform.position);
                        }
                        else
                        {
                            blocks.Add(newBlock);
                            decorLocations.Add(newBlock.transform.position);
                        }
                        UpdateBlocks();
                    }
                }
                if (destroy)
                {
                    blockLocations.Remove(blocks[tBD].transform.position);
                    decorLocations.Remove(blocks[tBD].transform.position);
                    Destroy(blocks[tBD]);
                    blocks.RemoveAt(tBD);
                    destroy = false;
                    UpdateBlocks();
                }

            }
        }
    }
    void UpdateBlocks()
    {
        foreach (var block in blocks)
        {
            if (block.GetComponent<BlockChangeScript>() != null)
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
}
