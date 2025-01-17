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
        txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
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
        transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector3(400, 50, 0);
        if (unlock)
        {
            txt.text = "" + title;
            txt.transform.position = new Vector3(0, -140);
            txt.color = Color.black;
        }
        else
        {
            //imgSprite.color = new Color(0.1f, 0.1f, 0.1f);
            transform.GetChild(0).GetComponent<Image>().color = Color.black;
        }
    }


}
