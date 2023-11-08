using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    
    public void PickUp()
    {
        inventory.items.Add(this);
    }
}
