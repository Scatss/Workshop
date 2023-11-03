using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnter;

    [SerializeField] private UnityEvent OnExit;

    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke();
        Debug.Log("Invoked enter!");
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke();
        Debug.Log("Invoked exit!");
    }
}
