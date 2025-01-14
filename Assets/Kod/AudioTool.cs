using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTool : MonoBehaviour
{
    AudioSource source;
    public float audioSpeed;
    bool fadeIn;
    bool fadeOut;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (source.volume > 0 && fadeOut)
        {
            source.volume -= Time.deltaTime;
        }
        else
        {
            fadeOut = false;
        }
        if (source.volume < 2 && fadeIn)
        {
            source.volume += Time.deltaTime;
        }
        else
        {
            fadeIn = false;
        }
    }
    public void FadeOutAudio()
    {
        fadeOut = true;
        fadeIn = false;
    }
    public void FadeInAudio()
    {
        fadeOut = false;
        fadeIn = true;
    }
}
