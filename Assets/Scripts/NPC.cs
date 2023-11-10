using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour, Interactable
{
    protected Animator animator;
    [SerializeField] private UnityEvent onInteract;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    UnityEvent Interactable.OnInteract
    {
        get => onInteract;
        set => onInteract = value;
    }

    public void InteractWith() => onInteract?.Invoke();
}
