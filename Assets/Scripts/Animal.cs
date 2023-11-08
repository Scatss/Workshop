using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : NPC
{
    [SerializeField] private Inventory inventory;
    private bool wasFed;

    public override void InteractWith()
    {
        base.InteractWith();
        
        Feed();

    }

    private void Feed()
    {
        if (inventory.FindItem(out Item item))
        {
            inventory.RemoveItem(item);
            Destroy(item);
            wasFed = true;
            
            animator.SetBool("Fed", true);
        }
    }
}
