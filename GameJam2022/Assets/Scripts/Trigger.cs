using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LevelManager levelManager;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (check == true)
                {
                levelManager.jump.maxValue = 20;
                levelManager.speed.maxValue = 20;
                levelManager.build.GetComponent<Animator>().SetTrigger("BuildUp");
                check = false;
            }
        }
    }
}
