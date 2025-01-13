using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutDestruct : SelfDestruct
{

    private Renderer objRenderer;
    private Color[] originalColors;
    private float fadeSpeed;
    private bool isFading = false;
    float timer;

    public override void Start()
    {
        // Get the renderer of the object
        objRenderer = GetComponent<Renderer>();

        Material[] materials = objRenderer.materials;
        originalColors = new Color[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            originalColors[i] = materials[i].color;
        }

        // Calculate the fade speed
        fadeSpeed = 1f / deathTimer;

        // Start fading
        isFading = true;
    }
    void Update()
    {
        if (isFading)
        {
            timer += Time.deltaTime;
            bool allTransparent = true;

            // Gradually fade out all materials
            Material[] materials = objRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                Color color = materials[i].color;
                color.a = Mathf.Max(0, color.a - fadeSpeed * Time.deltaTime);
                materials[i].color = color;

                // Check if any material still has alpha greater than 0
                if (color.a > 0)
                {
                    allTransparent = false;
                }
            }

            // If all materials are fully transparent, destroy the object
            if (allTransparent)
            {
                Destroy(gameObject);
            }
        }
    }
}