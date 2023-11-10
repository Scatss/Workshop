using System;
using UnityEngine;

public class Human : NPC
{
    private AudioSource source;
    
    [SerializeField] private Dialogue dialogue;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void Talk()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    
    public void SwitchDialogue(Dialogue newDialogue)
    {
        dialogue = newDialogue;
    }

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
