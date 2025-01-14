using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    bool FadeIn = false;
    bool FadeOut = false;
    Image sprite;
    float waitLoadTimer = 1.5f;

    private void Start()
    {
        sprite = GetComponent<Image>();
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

        if (FadeOut == true && sprite.color.a <= 1)
        {
            print("blacking");
            sprite.color += new Color(0, 0, 0, 1) * Time.deltaTime;
        }
        


        if (FadeIn && sprite.color.a > 0)
        {
            sprite.color -= new Color(0, 0, 0, 1) * Time.deltaTime;
        }
        else
        {
            FadeIn = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenFadeOut();
        }
    }
    

    public void ScreenFadeIn()
    {
        FadeIn = true;
        FadeOut = false;
    }

    public void ScreenFadeOut()
    {
        print("black");
        FadeOut = true;
        FadeIn = false;

    }
}
