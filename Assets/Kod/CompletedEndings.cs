using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedEndings : MonoBehaviour
{
    public bool[] endings = new bool[3];

    public void Start()
    {
        for (int i = 1; i < endings.Length+1; i++)
        {
            if (i == PlayerPrefs.GetInt("Ending"+i,0))
            {
                endings[i - 1] = true; 
            }
            
        }
    }

    public void CompleteEndning(int number)
    {
        if (endings[number-1] != null)
        {
            endings[number-1] = true;
            PlayerPrefs.SetInt("Ending" + number, number);
        }
        else
        {
            print("no ending to safe");
        }
        
    }

    public void resetCompletedEndings()
    {
        for (int i = 1; i < endings.Length + 1; i++)
        {
            PlayerPrefs.SetInt("Ending" + i, 0);
            endings[i - 1] = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CompleteEndning(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CompleteEndning(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CompleteEndning(3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCompletedEndings();
        }
    }

}
