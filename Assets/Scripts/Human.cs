using System;
using UnityEngine;

public class Human : NPC
{
    [SerializeField] private AudioClip angrySound;
    [SerializeField] private AudioClip happySound;

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

    public void PlaySound(ulong clip)
    {
        source.Play(clip);
    }
}
