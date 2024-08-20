using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string triggeringTag = "Player"; // The tag of the object that can trigger the pressure plate

    private bool isActivated = false;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Automatically find Animator on the same GameObject
        }
    }

    // This method is called when another collider enters the trigger collider attached to the pressure plate
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && !isActivated)
        {
            // Activate the pressure plate and trigger the animation
            isActivated = true;
            animator.SetBool("IsPressed", true);
        }
    }

    // Optional: Reset the pressure plate when the player leaves
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && isActivated)
        {
            // Deactivate the pressure plate and reset the animation
            isActivated = false;
            animator.SetBool("IsPressed", false);
        }
    }
}
    

