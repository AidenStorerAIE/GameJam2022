using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LineManager : MonoBehaviour
{
    public List<GameObject> lines;
    public List<GameObject> lineParents;
    public int layerCount;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

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
            line.transform.localPosition = new Vector3(line.transform.localPosition.x, line.transform.localPosition.y, 0);
        }
        foreach (var line in lineParents)
        {
            line.GetComponent<MeshCollider>().enabled = false;
            string localPath = "Assets/Prefabs/" + line.gameObject.name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(line, localPath);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
