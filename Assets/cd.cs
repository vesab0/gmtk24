using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd: MonoBehaviour
{
    public bool TouchingWall;
    public GameObject katrori;
    private bool hasInstantiatedPrefab;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform" || other.gameObject.tag== "cantMove")
        {
            TouchingWall = true;
            if (!hasInstantiatedPrefab)
            {
                Instantiate(katrori, transform.position, Quaternion.identity);
                hasInstantiatedPrefab = true; // Mark it as instantiated
            }
            if(other.gameObject.tag =="cantMove"){
                Debug.Log("e preka cantmovin");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform"|| other.gameObject.tag== "cantMove")
        {
            TouchingWall = false;

        }
    }
}