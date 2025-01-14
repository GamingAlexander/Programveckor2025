using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedEndings : MonoBehaviour
{
    public bool[] endings = new bool[3];
    public bool displaying;

    public void Start() //Checks which endings has been saved as completed 
    {
        for (int i = 1; i < endings.Length+1; i++) 
        {
            if (i == PlayerPrefs.GetInt("Ending"+i,0))
            {
                endings[i - 1] = true; 
            }
            
        }
        if (displaying)
        {
            GetComponent<DisplayEndings>().UpdateEndingsDisplay();
        }
    }

    public void CompleteEndning(int number) //saves ending x as complete 
    {
        endings[number - 1] = true;
        PlayerPrefs.SetInt("Ending" + number, number);
    }

    public void resetCompletedEndings() //all endings are incomplete 
    {
        for (int i = 1; i < endings.Length + 1; i++)
        {
            PlayerPrefs.SetInt("Ending" + i, 0);
            endings[i - 1] = false;
        }
    }

    private void Update() //temp
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCompletedEndings();
        }
    }

}
