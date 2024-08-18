using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cm : MonoBehaviour
{
    public bool TouchingWall;
    public GameObject katrori;
    public GameObject qeliza;
    public bool hasInstantiatedPrefab;
    private GameObject instantiatedKatrori;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            TouchingWall = true;
            if (!hasInstantiatedPrefab)
            {
                instantiatedKatrori = Instantiate(katrori, qeliza.transform.position, Quaternion.identity);
                instantiatedKatrori.transform.SetParent(qeliza.transform);
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