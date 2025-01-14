using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTool : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;
    public float audioSpeed;
    public bool complete = false;
    bool[] fadeIn;
    bool[] fadeOut;
   

    private void Start()
    {
        fadeIn = new bool[sources.Length];
        fadeOut = new bool[sources.Length];
        FadeInAudio(0);
    }
    private void Update()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            FadingOut(i);
        }
        for (int i = 0; i < sources.Length; i++)
        {
            FadingIn(i);
        }
    }
    private void FadingOut(int index)
    {
        if (sources[index].volume > 0 && fadeOut[index])
        {
            sources[index].volume -= Time.deltaTime;
        }
        else
        {
            fadeOut[index] = false;
        }
    }
    private void FadingIn(int index)
    {
        if (sources[index].volume < 1 && fadeIn[index])
        {
            sources[index].volume += Time.deltaTime;
        }
        else
        {
            fadeIn[index] = false;
        }
    }
    public void FadeOutAudio(int index)
    {
        fadeOut[index] = true;
    }
    public void FadeInAudio(int index)
    {
        fadeIn[index] = true;
    }
    public void FadeOutAllAudio()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            fadeOut[i] = true;
        }

    }
    public void FadeInAllAudio()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            fadeIn[i] = true;
        }
    }
}
