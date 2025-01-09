using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndDisplay : MonoBehaviour
{
    Image imgSprite;
    TextMeshProUGUI txt;
    bool unlock = false;
    public string title;
    private void Awake()
    {
        imgSprite = GetComponent<Image>();
        txt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
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
            txt.text = "" + title;
            txt.color = Color.black;
            imgSprite.color = Color.white;
            txt.transform.position = new Vector3(0, -80);
            
        }
        else
        {
            imgSprite.color = new Color(0.2f, 0.2f, 0.2f);
        }
    }


}
