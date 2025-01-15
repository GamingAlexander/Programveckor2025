using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScreen : MonoBehaviour
{
    bool FadeOut = false;
    Image sprite;
    Canvas canvas;
    float fadeSpeed = 1f; // Hastighet p� faderingen

    private void Start()
    {
        sprite = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>(); // H�mta canvas-komponenten fr�n f�r�ldern
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
            // Minska alpha f�r att g�ra bilden mer transparent
            sprite.color -= new Color(0, 0, 0, fadeSpeed * Time.deltaTime);

            // Kontrollera om faderingen �r klar
            if (sprite.color.a <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0); // S�tt alpha till exakt 0
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
            canvas.sortingOrder = 1; // �ndra canvas sorteringsordning n�r faderingen �r klar
        }

        // Eventuella ytterligare �tg�rder h�r
    }
}