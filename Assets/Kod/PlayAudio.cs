using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    public bool prioriticeAudio;
    public float TempVolume;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void playAudio(int index)
    {
        source.clip = clips[index];
        source.pitch = Random.Range(0.8f, 1.1f);
        if (prioriticeAudio && source.isPlaying)
        {
            return;
        }
       
        if (TempVolume != 0)
        {
            source.volume += TempVolume;
        }
        source.Play();
        if (prioriticeAudio)
        {
            prioriticeAudio = false;
        }
    }
}
