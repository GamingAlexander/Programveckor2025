using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void playAudio(int index)
    {
        source.clip = clips[index];
        source.pitch = Random.Range(0.8f, 1.1f);
        source.Play();
        print("player" + clips[index]);
    }
}
