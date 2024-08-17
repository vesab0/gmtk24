using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM : MonoBehaviour
{
    public bool TouchingWall;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform" || other.gameObject.tag== "Player")
        {
            TouchingWall = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform"|| other.gameObject.tag== "Player")
        {
            TouchingWall = false;
        }
    }
}
