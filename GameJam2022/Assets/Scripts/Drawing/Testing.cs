using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject background;
    public GameObject character;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Test()
    {
        if (!test)
        {
            background.SetActive(false);
            character.GetComponent<Animator>().enabled = true;
            test = true;
        }
        else if (test)
        {
            background.SetActive(true);
            character.GetComponent<Animator>().enabled = false;
            test = false;
        }
    }
}
