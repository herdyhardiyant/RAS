using System.Collections.Generic;
using DataStorage;
using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset inventoryTreeAsset;
        [SerializeField] private ItemActionWindow itemActionWindow;
        [SerializeField] private ItemSlotsManipulator itemSlotsManipulator;

        public VisualElement InventoryVisualElement => _inventoryRoot;
        
        private VisualElement _inventoryRoot;

        void Awake()
        {
            _inventoryRoot = inventoryTreeAsset.CloneTree();
            SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            
            itemSlotsManipulator.OnClickIndividualItemSlot((itemDataOnSlot =>
            {
                if (itemDataOnSlot == null)
                    return;
                
                itemActionWindow.ShowItemActionWindow(itemDataOnSlot);
                
            }));
        }

        private void CloseInventory()
        {
            itemActionWindow.Hide();
            itemSlotsManipulator.ResetSlotFocus();
        }
    }
}