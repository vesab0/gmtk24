using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenSplit : MonoBehaviour
{
    private GameObject playerWithHighestXAtSmallestY;
    private GameObject playerWithLowestXAtHighestY;
    private float lastDistance = -1f;
    private bool resizingActive;
    public float distanceThreshold = 0.2f; // Set your threshold here

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            resizingActive = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            resizingActive = false;
        }

        // Find all objects with the "Player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Check if there are any players in the scene
        if (players.Length == 0)
        {
            return; // No players to process
        }

        // Initialize tracking variables
        float smallestY = Mathf.Infinity;
        float highestY = -Mathf.Infinity;

        playerWithHighestXAtSmallestY = null;
        playerWithLowestXAtHighestY = null;

        // First pass: Find the players with the smallest Y and highest Y
        foreach (GameObject player in players)
        {
            float playerY = player.transform.position.y;
            float playerX = player.transform.position.x;

            if (playerY < smallestY)
            {
                // New smallest Y found
                smallestY = playerY;
                playerWithHighestXAtSmallestY = player;
            }
            else if (Mathf.Approximately(playerY, smallestY))
            {
                // If the player's Y is equal to the smallest Y, check X for the highest
                if (playerX > playerWithHighestXAtSmallestY.transform.position.x)
                {
                    playerWithHighestXAtSmallestY = player;
                }
            }

            if (playerY > highestY)
            {
                // New highest Y found
                highestY = playerY;
                playerWithLowestXAtHighestY = player;
            }
            else if (Mathf.Approximately(playerY, highestY))
            {
                // If the player's Y is equal to the highest Y, check X for the lowest
                if (playerX < playerWithLowestXAtHighestY.transform.position.x)
                {
                    playerWithLowestXAtHighestY = player;
                }
            }
        }

        if (playerWithHighestXAtSmallestY != null && playerWithLowestXAtHighestY != null)
        {
            Vector3 positionA = playerWithHighestXAtSmallestY.transform.position;
            Vector3 positionB = playerWithLowestXAtHighestY.transform.position;
            float currentDistance = Vector3.Distance(positionA, positionB);

            // Log only if the distance changes significantly
            if (lastDistance < 0 || Mathf.Abs(currentDistance - lastDistance) > distanceThreshold)
            {  
                lastDistance = currentDistance; // Update lastDistance
                
                // Loop through each player and call freezeobjects()
                foreach (GameObject player in players)
                {
                    move moveScript = player.GetComponent<move>();
                    if (moveScript != null)
                    {
                        moveScript.freezeobjects();
                    }
                }
            }
        }
    }
}
