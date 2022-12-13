using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPreviews : MonoBehaviour
{
    public List<GameObject> items;
    LevelEditor levelEditor;
    public int lastInt;

    // Start is called before the first frame update
    void Start()
    {
        lastInt = 100;
        levelEditor = FindObjectOfType<LevelEditor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastInt != levelEditor.i)
        {
            foreach (GameObject item in items)
            {
                item.active = false;
            }
            lastInt = levelEditor.i;
            items[levelEditor.i].active = true;

        }
    }
}
