using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LineManager : MonoBehaviour
{
    public List<GameObject> lines;
    public GameObject lineParent;
    public int layerCount;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAll()
    {
        foreach (var line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
        layerCount = 0;
    }
    public void Save()
    {
        foreach (var line in lines)
        {
            line.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        string localPath = "Assets/Prefabs/" + lineParent.gameObject.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(lineParent, localPath);
    }
    //public void Undo()
    //{
    //    if (lines.Count > 0)
    //    {
    //        Destroy(lines[lines.Count - 1]);
    //        lines.RemoveAt(lines.Count - 1);
    //    }
    //}
    }
