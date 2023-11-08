using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField] public List<Item> items;

   private void Awake()
   {
      items = new List<Item>();
   }

   public bool FindItem<T>(out T found) where T : Item
   {
      foreach (Item item in items)
      {
         if (item is not T typed) continue;
         
         found = typed;
         return true;
      }

      found = default;
      return false;
   }

   public void RemoveItem(Item item)
   {
      items.Remove(item);
   }
}
