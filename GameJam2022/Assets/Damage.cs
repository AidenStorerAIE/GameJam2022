using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float damage = collision.gameObject.GetComponent<PlayerMovement>().stompSliderValue;
            DealDamage(damage);
        }
    }

    void DealDamage(float damage)
    {
        this.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
    }
}
