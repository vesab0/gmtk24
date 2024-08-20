using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureplate : MonoBehaviour
{
    public BoxCollider2D Sensor;

    Animator anim;

    
        
        // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Sensor)
        {
            anim.SetInteger("State", 1);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Sensor)
        {
            anim.SetInteger("State", 0);
        }

    }
}


