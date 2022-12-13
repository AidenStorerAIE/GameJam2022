using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proc : MonoBehaviour
{
    public DontDestroyLoad dontDestroyLoad;
    // Start is called before the first frame update
    void Start()
    {
        dontDestroyLoad = FindObjectOfType<DontDestroyLoad>();
        dontDestroyLoad.NewScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
