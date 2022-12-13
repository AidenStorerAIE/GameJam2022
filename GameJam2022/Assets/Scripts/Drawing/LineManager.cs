using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
