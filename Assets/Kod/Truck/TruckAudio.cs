using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAudio : MonoBehaviour
{
    AudioSource source;
    Rigidbody2D rg;
    [SerializeField] AudioClip[] clips;
    bool start = true;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rg != null)
        {
            if (rg.velocity.magnitude > 0.01f)
            {
                source.volume = 1;
                if (start)
                {
                    StartEngineAudio();
                    Invoke("EngineAudio", 1.2f);
                    start = false;
                }
               
            }
            else
            {
                source.volume = 0;
                start = true;
            }
            source.pitch = rg.velocity.magnitude/4.5f;
        }
       
        
    }

    private void StartEngineAudio()
    {
        source.loop = false;
        source.clip = clips[0];
        source.volume = 0.5f;
        source.Play();
    }

    private void EngineAudio()
    {
        source.loop = true;
        source.clip = clips[1];
        source.volume = 1f;
        source.Play();
    }
}
