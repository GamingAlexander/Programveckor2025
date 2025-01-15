using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScreen : MonoBehaviour
{
    private bool fadeIn = false;
    private Image sprite;
    private float fadeSpeed = 1f; // Hastighet p� faderingen
    Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        sprite = GetComponent<Image>();

        // S�tt initial alpha till 0 (osynlig)
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
    }

    private void Update()
    {
        if (fadeIn)
        {
            // �ka alpha f�r att g�ra bilden mer synlig
            sprite.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);

            // Kontrollera om faderingen �r klar
            if (sprite.color.a >= 1)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1); // S�tt alpha till exakt 1
                fadeIn = false;
            }
        }
    }

    public void StartFadeIn()
    {
        canvas.sortingOrder = 1;
        fadeIn = true;
    }
}
