using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface Interactable
{
    public UnityEvent OnInteract { get; protected set; }
    
    public void InteractWith();
}
