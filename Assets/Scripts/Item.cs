using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform playerHand;

    private bool hasBeenPickedUp;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void PickUp()
    {
        inventory.items.Add(this);
        if (animator != null)
        {
            animator.enabled = false;
        }
        hasBeenPickedUp = true;
    }

    private void FixedUpdate()
    {
        if (hasBeenPickedUp)
        {
            transform.position = playerHand.position;
        }
    }
}
