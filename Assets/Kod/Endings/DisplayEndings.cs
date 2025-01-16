using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayEndings : MonoBehaviour
{
    CompletedEndings saved;
    float length;
    //[SerializeField] Font fontStyle;
    [SerializeField] TMP_FontAsset fontAsset;
    
    [SerializeField] GameObject endingIconPrefab;
    [SerializeField] string[] endingTitles;
    [SerializeField] Sprite[] endingSprites;

    public void UpdateEndingsDisplay()
    {
        saved = GetComponent<CompletedEndings>();
        length = saved.endings.Length;
        for (int i = 0; i < length; i++)
        {
            GameObject newDisplay = Instantiate(endingIconPrefab, Vector3.zero, Quaternion.identity, transform);
            
            newDisplay.transform.GetChild(0).GetComponent<Image>().sprite = endingSprites[i];
            newDisplay.transform.GetChild(1).GetComponent<TextMeshProUGUI>().font = fontAsset;
            if (saved.endings[i] == true)
            {
                newDisplay.GetComponent<EndDisplay>().title = endingTitles[i];
                newDisplay.GetComponent<EndDisplay>().Unlocked();
            }
            else
            {
                //newDisplay.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
