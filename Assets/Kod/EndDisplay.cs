using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDisplay : MonoBehaviour
{
    Image imgSprite;
    bool unlock = false;
    private void Awake()
    {
        imgSprite = GetComponent<Image>();
    }

    private void Start()
    {
        UpdateDisplay();
    }
    public void Unlocked()
    {
        unlock = true;
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        if (unlock)
        {
            if (imgSprite==null)
            {
                print("no sprite");
            }
            imgSprite.color = Color.white;
        }
        else
        {
            imgSprite.color = new Color(0.2f, 0.2f, 0.2f);
        }
    }


}
