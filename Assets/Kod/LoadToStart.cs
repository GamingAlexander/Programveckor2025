using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadToStart : MonoBehaviour
{
    public float loadTimer;
    [SerializeField] AudioTool source;
    [SerializeField] GameObject screen;
    bool screenStart;
   
    void Update()
    {
        if (loadTimer > 0)
        {
            loadTimer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        if (loadTimer < 1 && screenStart)
        {
            screenStart = false;
            
            source.FadeOutAllAudio();
        }
        if (loadTimer < 1)
        {
            screen.GetComponent<Image>().color += new Color(0, 0, 0, 1) * Time.deltaTime;
        }
       
    }
}
