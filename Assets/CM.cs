using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM : MonoBehaviour
{
    public bool TouchingWall;
    public bool TouchingPlayer;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = true;
        }
        if(other.gameObject.tag== "Player" || other.gameObject.tag== "bossi" || other.gameObject.tag== "potencialbossiD" || other.gameObject.tag== "potencialbossiM")
        {
            TouchingPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = false;
        }
        if(other.gameObject.tag== "Player" || other.gameObject.tag== "bossi" || other.gameObject.tag== "potencialbossiD" || other.gameObject.tag== "potencialbossiM")
        {
            TouchingPlayer = false;
        }
    }
}
