using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : NPC
{
    [SerializeField] private Inventory inventory;
    private bool wasFed;

    public void Feed()
    {
        if (inventory.FindItem(out Food food))
        {
            inventory.RemoveItem(food);
            Destroy(food.gameObject);
            wasFed = true;
            
            animator.SetBool("Fed", true);
        }
    }
}
