using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMultiplier : MonoBehaviour
{
    public GameObject cubePrefab; // Drag your cube prefab here in the Inspector
    public float distance = 1.0f; // Distance between cubes when they multiply

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MultiplyCube(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MultiplyCube(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MultiplyCube(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MultiplyCube(Vector3.right);
        }
    }

    void MultiplyCube(Vector3 direction)
    {
        // Instantiate a new cube at the current position plus the direction
        Vector3 newPosition = transform.position + direction * distance;
        Instantiate(cubePrefab, newPosition, Quaternion.identity);
    }
}