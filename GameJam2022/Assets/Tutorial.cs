using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    AudioSource _aiden;
    private bool check;
    // Start is called before the first frame update
    void Start()
    {
        _aiden = GetComponent<AudioSource>();
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (check)
            {
                _aiden.Play();
                check = false;
            }
        }
    }
}
