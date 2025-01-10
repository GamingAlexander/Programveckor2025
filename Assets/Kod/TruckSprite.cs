using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSprite : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Transform rotObj;
    SpriteRenderer playerSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rotObj = transform.parent;
    }

    void Update()
    {
        UpdateSpriteBasedOnRotation();
        transform.eulerAngles = Vector3.zero;
    }

    void UpdateSpriteBasedOnRotation()
    {
       
        int directionIndex = Mathf.RoundToInt((rotObj.eulerAngles.z / 45f)) % 8;

        if (directionIndex < 0)
        {
            directionIndex += 8;
        }

        if (sprites.Length == 8)
        {
            playerSprite.sprite = sprites[directionIndex];
        }
    }
}
