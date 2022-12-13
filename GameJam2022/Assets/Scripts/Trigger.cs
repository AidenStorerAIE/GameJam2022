using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelManager.jump.maxValue = 20;
            levelManager.speed.maxValue = 20;
            levelManager.build.GetComponent<Animator>().SetTrigger("BuildUp");
            Destroy(this.gameObject);
        }
    }
}
