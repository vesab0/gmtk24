using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f;           // Speed at which the player will move horizontally
    public float gravity = -9.8f;          // Gravity force applied to the player
    public LayerMask collisionMask;       // Layer mask to determine which layers will block movement
    public Transform groundCheck;         // A transform placed at the player's feet for ground detection
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle
    public LayerMask groundLayer;         // Layer for ground detection

    private Vector2 velocity;             // Current velocity of the player
    private BoxCollider2D boxCollider;    // Reference to the BoxCollider2D component
    private bool isGrounded;              // Flag to determine if the player is on the ground

    void Start()
    {
        // Get the BoxCollider2D component
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;

        // Apply horizontal movement
        velocity.x = moveDirection.x * moveSpeed;

        // Apply gravity only if the player is not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0; // Stop falling when grounded
        }

        // Calculate new position
        Vector2 newPosition = (Vector2)transform.position + velocity * Time.deltaTime;

        // Check for collisions before moving
        if (!IsColliding(newPosition))
        {
            // Move the object to the new position
            transform.position = newPosition;
        }
    }

    bool IsColliding(Vector2 newPosition)
    {
        // Create a box that represents the new position of the collider
        Bounds bounds = boxCollider.bounds;
        bounds.center = newPosition;

        // Check if the box overlaps with any colliders in the collision mask
        Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0, collisionMask);
        foreach (var col in colliders)
        {
            // Ensure the collided object is not the current object itself
            if (col.gameObject != this.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmos()
    {
        // Draw the collider bounds in the Scene view for debugging
        if (boxCollider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
        }

        // Draw ground check position for debugging
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
