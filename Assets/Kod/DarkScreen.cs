using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    bool FadeIn = false;
    bool FadeOut = false;
    Image sprite;
    Canvas canvas;
    float waitLoadTimer = 1.5f;

    private void Start()
    {
        sprite = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>(); // H�mta canvas-komponenten fr�n f�r�ldern
    }

    private void Update()
    {
        if (waitLoadTimer > 0)
        {
            waitLoadTimer -= Time.deltaTime;
        }
        else
        {
            if (waitLoadTimer != -1)
            {
                ScreenFadeIn();
            }
            waitLoadTimer = -1;
        }

        if (FadeOut && sprite.color.a < 1)
        {
            sprite.color += new Color(0, 0, 0, 1) * Time.deltaTime;
            if (sprite.color.a >= 1)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1); // S�kerst�ll att alpha �r exakt 1
                FadeOutComplete();
            }
        }

        if (FadeIn && sprite.color.a > 0)
        {
            sprite.color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            if (sprite.color.a <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0); // S�kerst�ll att alpha �r exakt 0
                FadeInComplete();
            }
        }
    }

    public void ScreenFadeIn()
    {
        FadeIn = true;
        FadeOut = false;
    }

    public void ScreenFadeOut()
    {
        FadeOut = true;
        FadeIn = false;
    }

    private void FadeInComplete()
    {
        FadeIn = false;
        Debug.Log("Fade In Complete");
        if (canvas != null)
        {
            canvas.sortingOrder = -1; // �ndra canvas sorteringsordning n�r faderingen �r klar
        }
    }

    private void FadeOutComplete()
    {
        FadeOut = false;
        Debug.Log("Fade Out Complete");
        if (canvas != null)
        {
            canvas.sortingOrder = -1; // �ndra canvas sorteringsordning n�r faderingen �r klar
        }
    }
}
