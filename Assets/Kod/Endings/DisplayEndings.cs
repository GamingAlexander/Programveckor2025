using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEndings : MonoBehaviour
{
    CompletedEndings saved;
    float length;
    [SerializeField] GameObject endingIconPrefab;
    [SerializeField] string[] endingTitles;
    
    public void UpdateEndingsDisplay()
    {
        saved = GetComponent<CompletedEndings>();
        length = saved.endings.Length;
        for (int i = 0; i < length; i++)
        {
            GameObject newDisplay = Instantiate(endingIconPrefab, Vector3.zero, Quaternion.identity, transform);
            if (saved.endings[i] == true)
            {
                newDisplay.GetComponent<EndDisplay>().title = endingTitles[i];
                newDisplay.GetComponent<EndDisplay>().Unlocked();
            }
        }
    }
}
