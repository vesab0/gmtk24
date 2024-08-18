using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSD : MonoBehaviour
{
    public GameObject lowestObject;
    void Update(){
        
        float lowestY = float.PositiveInfinity;

        // Retrieve all objects with the "Player" or "bossi" tag

        GameObject[] bossiObjects = GameObject.FindGameObjectsWithTag("potencialbossiD");

        // Combine the arrays
        GameObject[] relevantObjects = new GameObject[bossiObjects.Length];

        bossiObjects.CopyTo(relevantObjects, 0);

        // Iterate through all the relevant objects
        foreach (GameObject obj in relevantObjects)
        {
            Transform objTransform = obj.transform;
            if (objTransform != null)
            {
                float currentY = objTransform.position.y;
                if (currentY < lowestY)
                {
                    lowestY = currentY;
                    lowestObject = obj;
                }
            }
        }
    }
}