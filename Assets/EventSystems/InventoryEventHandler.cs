using System;
using UnityEngine;

namespace EventSystems
{
    public static class InventoryEventHandler
    {
       public static event Action onInventoryChanged;
       
       public static void InvokeInventoryChangedEvent()
       {
           onInventoryChanged?.Invoke();
       }
       
    }
}
