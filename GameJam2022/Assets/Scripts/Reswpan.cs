using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reswpan : MonoBehaviour
{
    public RespawnManager respawnManager;
    public GameObject fire;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        fire.SetActive(false);
        check = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (check)
        {
            if (other.gameObject.tag == "Player")
            {
                fire.SetActive(true);
                respawnManager.spawnsPoints.Add(this.gameObject);
                check = false;
            }
        }
    }

}
