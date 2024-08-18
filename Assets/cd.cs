using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd : MonoBehaviour
{
    public bool TouchingWall;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = true;
            
            if(other.gameObject.tag =="cantMove"){
                Debug.Log("e preka cantmovin");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = false;

        }
    }
}