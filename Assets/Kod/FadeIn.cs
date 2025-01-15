using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScreen : MonoBehaviour
{
    bool FadeOut = false;
    Image sprite;
    Canvas canvas;
    float fadeSpeed = 1f; // Hastighet på faderingen

    private void Start()
    {
        sprite = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>(); // Hämta canvas-komponenten från föräldern
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.sortingOrder = 1;
            StartFadeOut();
        }
        if (FadeOut)
        {
            // Minska alpha för att göra bilden mer transparent
            sprite.color -= new Color(0, 0, 0, fadeSpeed * Time.deltaTime);

            // Kontrollera om faderingen är klar
            if (sprite.color.a <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0); // Sätt alpha till exakt 0
                FadeOutComplete();
            }
        }
    }

    public void StartFadeOut()
    {
        FadeOut = true;
    }

    private void FadeOutComplete()
    {
        FadeOut = false;
        Debug.Log("Fade Out Complete");
        if (canvas != null)
        {
            canvas.sortingOrder = 1; // Ändra canvas sorteringsordning när faderingen är klar
        }

        // Eventuella ytterligare åtgärder här
    }
}