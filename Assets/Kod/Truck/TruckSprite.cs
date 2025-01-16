using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSprite : MonoBehaviour
{
    [SerializeField] Sprite[] sprites; // Array of 8 directional sprites
    [SerializeField] GameObject dragParticleEffect; // Prefab 
    [SerializeField] GameObject sandParticleEffect; // Prefab 
    [SerializeField] int particleWait;
   
    int particleCounter = 0;
    bool left;
    public bool drag = false;
    
    public float timerAudio;

    private Transform rotObj;
    private SpriteRenderer playerSprite;
    PlayAudio audio;

    public int currentDirectionIndex = -1; // Keeps track of the current direction index
    private Rigidbody2D rb; // To track movement direction
    

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rotObj = transform.parent;
        rb = rotObj.GetComponent<Rigidbody2D>(); // Ensure the parent has a Rigidbody2D
        audio = transform.parent.GetChild(1).GetComponent<PlayAudio>();
    }

    void Update()
    {
        UpdateSpriteBasedOnRotation();
        transform.eulerAngles = Vector3.zero; // Keep local rotation fixed

    }

    void FixedUpdate()
    {
        DragUpdate();
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
                //UpdateLights(directionIndex);
            }

            // Update the current direction index
            currentDirectionIndex = directionIndex;
        }
    }

    void DragUpdate()
    {
        if (rotObj.GetComponent<drive>().backing)
        {
            return;
        }
 
            

        // Get the forward direction based on the sprite direction
        Vector2 forwardDirection = DirectionFromIndex(currentDirectionIndex);

        // Get the velocity direction of the parent object
        Vector2 velocity = rb.velocity;
        Vector2 velocityDirection = velocity.normalized;

        // Check if the object is moving
        if (velocity.magnitude < 0.5f)
        {
            return;
        }
       
        if (rotObj.GetComponent<drive>().bracking)
        {
            TireDrag(0.9f);
           
            return;
        }
            
        // Calculate misalignment angle
        float angleDifference = Vector2.Angle(forwardDirection, velocityDirection);

        // Spawn particles if misalignment is significant
        if (angleDifference > 20f && Random.value <= 0.8f) // Adjust the threshold as needed
        {
            TireDrag(0.7f);
        }
        else
        {
            timerAudio -= Time.deltaTime;
        }
        
    }

    Vector2 DirectionFromIndex(int index)
    {
        // Map direction index to corresponding unit vector
        switch (index)
        {
            case 0: return Vector2.up; // 0° (North)
            case 1: return new Vector2(-1, 1).normalized; // 315° (Northwest)
            case 2: return Vector2.left; // 270° (West)
            case 3: return new Vector2(-1, -1).normalized; // 225° (Southwest)
            case 4: return Vector2.down; // 180° (South)
            case 5: return new Vector2(1, -1).normalized; // 135° (Southeast)
            case 6: return Vector2.right; // 90° (East)
            case 7: return new Vector2(1, 1).normalized; // 45° (Northeast)
            default: return Vector2.zero;
        }
    }

    private void TireDrag(float chance)
    {
        
        if (timerAudio <= 0)
        {
            audio.playAudio(0);
            timerAudio = 0.5f;
        }
        float spred = 0.15f;
        float offset = 0;
        if (currentDirectionIndex == 2 || currentDirectionIndex == 3 || currentDirectionIndex == 1)
        {
            offset = -0.25f;
        }
        if (currentDirectionIndex == 5 || currentDirectionIndex == 6 || currentDirectionIndex == 7)
        {
            offset = 0.25f;
        }
        
        GenerateParticles(spred + offset, chance);
        GenerateParticles(-spred + offset, chance);
        drag = true;
    }

    private void GenerateParticles(float pos, float chance)
    {
        if (particleCounter == particleWait)
        {
            if (Random.Range(0, 1) <= chance)
            {
                CreateParticle(pos);
                if (left)
                {
                    left = false;
                    particleCounter = 0;
                }
                else
                {
                    left = true;
                }
            }
        }
        else
        {
            particleCounter++;
        }
        
    }

    private void CreateParticle(float pos)
    {
        if (rotObj.transform.GetComponent<drive>().offroad)
        {
            Instantiate(sandParticleEffect, transform.position + rotObj.up * -0.6f + rotObj.right * pos, rotObj.transform.rotation);
        }
        else
        {
            Instantiate(dragParticleEffect, transform.position + rotObj.up * -0.6f + rotObj.right * pos, rotObj.transform.rotation);
        }
    }

    private void UpdateLights(int z)
    {
        transform.GetChild(0).eulerAngles = new Vector3(0, 0, z * 45);
        transform.GetChild(1).eulerAngles = new Vector3(0, 0, 180 + z * 45);
    }
}

