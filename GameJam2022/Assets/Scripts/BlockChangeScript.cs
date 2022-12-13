using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChangeScript : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;    
    public GameObject bottomLeft;
    public GameObject bottomRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Top()
    {
        top.SetActive(true);
        bottom.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);        
        bottomLeft.SetActive(false);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void Bottom()
    {
        top.SetActive(false);
        bottom.SetActive(true);
        left.SetActive(false);
        right.SetActive(false);
        bottomLeft.SetActive(false);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }
    public void Left()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(true);
        right.SetActive(false);
        bottomLeft.SetActive(false);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void Right()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(false);
        right.SetActive(true);
        bottomLeft.SetActive(false);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void Center()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(true);
        right.SetActive(true);
        bottomLeft.SetActive(false);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void BottomLeft()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        bottomLeft.SetActive(true);
        bottomRight.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void BottomRight()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        bottomLeft.SetActive(false);
        bottomRight.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void BottomCenter()
    {
        top.SetActive(false);
        bottom.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        bottomLeft.SetActive(true);
        bottomRight.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }
}
