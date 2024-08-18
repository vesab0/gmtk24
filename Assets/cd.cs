using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd : MonoBehaviour
{
    public bool TouchingWall;
    public bool TouchingGuy;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = true;
        }
        else if(other.gameObject.tag == "Player"){
            TouchingGuy = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = false;

        }
        else if(other.gameObject.tag == "Player"){
            TouchingGuy = false;
        }
    }
}