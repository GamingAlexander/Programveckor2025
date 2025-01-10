using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSprite : MonoBehaviour
{
    [SerializeField] Sprite[] sprites; // Array of 8 directional sprites
    [SerializeField] GameObject dragParticleEffectPrefab; // Prefab for drag particle effect
    private Transform rotObj;
    private SpriteRenderer playerSprite;

    private int currentDirectionIndex = -1; // Keeps track of the current direction index
    private Rigidbody2D rb; // To track movement direction

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rotObj = transform.parent;
        rb = rotObj.GetComponent<Rigidbody2D>(); // Ensure the parent has a Rigidbody2D
    }

    void Update()
    {
        UpdateSpriteBasedOnRotation();
        transform.eulerAngles = Vector3.zero; // Keep local rotation fixed

    }

    void FixedUpdate()
    {
        CheckForDragParticles();
    }

    void UpdateSpriteBasedOnRotation()
    {
        // Calculate direction index based on rotation
        int directionIndex = Mathf.RoundToInt((rotObj.eulerAngles.z / 45f)) % 8;

        // Handle negative indices
        if (directionIndex < 0)
        {
            directionIndex += 8;
        }

        // Change sprite if direction changes
        if (directionIndex != currentDirectionIndex)
        {
            if (sprites.Length == 8)
            {
                playerSprite.sprite = sprites[directionIndex];
            }

            // Update the current direction index
            currentDirectionIndex = directionIndex;
        }
        Debug.Log($"Direction Index: {directionIndex}, Expected Sprite: {sprites[directionIndex].name}");
    }

    void CheckForDragParticles()
    {
        if (dragParticleEffectPrefab == null || rb == null)
            return;

        // Get the forward direction based on the sprite direction
        Vector2 forwardDirection = DirectionFromIndex(currentDirectionIndex);

        // Get the velocity direction of the parent object
        Vector2 velocity = rb.velocity;
        Vector2 velocityDirection = velocity.normalized;

        // Check if the object is moving
        if (velocity.magnitude < 0.1f)
            return;

        // Calculate misalignment angle
        float angleDifference = Vector2.Angle(forwardDirection, velocityDirection);

        // Debug log for angle difference
        // Debug.Log($"Angle Difference: {angleDifference}, Velocity Magnitude: {velocity.magnitude}");

        // Spawn particles if misalignment is significant
        if (angleDifference > 20f && Random.value <= 0.2f) // Adjust the threshold as needed
        {
            Instantiate(dragParticleEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    Vector2 DirectionFromIndex(int index)
    {
        // Map direction index to corresponding unit vector
        switch (index)
        {
            case 0: return Vector2.up; // 0° (North)
            case 1: return new Vector2(1, 1).normalized; // 45° (Northeast)
            case 2: return Vector2.right; // 90° (East)
            case 3: return new Vector2(1, -1).normalized; // 135° (Southeast)
            case 4: return Vector2.down; // 180° (South)
            case 5: return new Vector2(-1, -1).normalized; // 225° (Southwest)
            case 6: return Vector2.left; // 270° (West)
            case 7: return new Vector2(-1, 1).normalized; // 315° (Northwest)
            default: return Vector2.zero;
        }
    }
}

