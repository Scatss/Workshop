using System;
using UnityEngine;

public class Human : NPC
{
    private AudioSource source;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    
    public override void InteractWith()
    {
        base.InteractWith();

        Talk();
    }

    private void Talk()
    {
        Console.WriteLine("Talking...");
    }

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
