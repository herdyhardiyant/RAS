using System.Collections.Generic;
using System.Linq;
using DataStorage;
using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset inventoryTreeAsset;

        [SerializeField] private VisualTreeAsset itemActionWindowTreeAsset;
        [SerializeField] private GameObject player;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _inventoryRoot;
        private VisualElement _itemSlotsContainer;
        private VisualElement _itemModalContainer;
        
        private int _playerInventoryItemCountBeforeInventoryChange;

        private const int DropItemDistanceFromPlayer = 2;

        private const string ItemSlotClass = "item-slot";
        
        private List<ItemSlot> _itemSlotsList = new List<ItemSlot>();
        private ItemSlotsManipulator _itemSlotsManipulator;

        void Awake()
        {
            _inventoryRoot = inventoryTreeAsset.CloneTree();
            _itemSlotsContainer = _inventoryRoot.Query<VisualElement>("item-slots");

            _itemModalContainer = _inventoryRoot.Query<VisualElement>("item-modal-container");
            _itemModalContainer.visible = false;

            SubscribeEvents();
            _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
        }

        private void Start()
        {
            CreateItemSlots();
        }


        private void CreateItemSlots()
        {
            var maxItemSlots = PlayerInventory.MaxInventorySize;
            
            _itemSlotsManipulator = new ItemSlotsManipulator(maxItemSlots, ItemSlotClass);
            
            _itemSlotsManipulator.OnClickIndividualItemSlot((itemDataOnSlot =>
            {
                if(itemDataOnSlot == null)
                    return;

                var itemModal = BuildItemActionWindow(itemDataOnSlot);
                ShowItemActionWindow(itemModal);

            }));
            
            _itemSlotsList = _itemSlotsManipulator.ItemSlots;
        
            foreach (var slot in _itemSlotsList)
            {
                print(slot.Name);
                print(slot.SlotVisualElement);
                _itemSlotsContainer.Add(slot.SlotVisualElement);
            }
            
        }
        
        private void CloseInventory()
        {
            _itemSlotsManipulator.ResetSlotFocus();

            _itemModalContainer.Clear();
            _itemModalContainer.visible = false;
        }

        private void InventoryDataItemsToSlots()
        {
            var playerInventoryData = PlayerInventory.Inventory;
            
            for (int i = 0; i < playerInventoryData.Count; i++)
            {
                var itemData = playerInventoryData[i];
                _itemSlotsList[i].AddItemToSlot(itemData);
            }
        }

        private void ClearItemSlots()
        {
            for (int i = 0; i < _playerInventoryItemCountBeforeInventoryChange; i++)
            {
                _itemSlotsList[i].RemoveItemFromSlot();
                var itemSlot = _itemSlotsContainer.Query($"slot-{i}").First();
                itemSlot.style.backgroundImage = null;
            }
        }

        private void ShowItemActionWindow(TemplateContainer itemModalWindow)
        {
            _itemModalContainer.visible = true;
            _itemModalContainer.Clear();

            _itemModalContainer.Add(itemModalWindow);
        }

        private TemplateContainer BuildItemActionWindow(ItemData item)
        {
            var itemModalWindow = itemActionWindowTreeAsset.CloneTree();
            itemModalWindow.Query<Label>("item-name").First().text = item.Name;
            itemModalWindow.Query<Label>("item-description").First().text = item.Description;
            itemModalWindow.Query<Button>("use-button").First().clicked += () => { print($"{item.Name} is used"); };
            itemModalWindow.Query<Button>("drop-button").First().clicked += () =>
            {
                DropItem(item);
                _itemModalContainer.Clear();
            };

            return itemModalWindow;
        }

        private void DropItem(ItemData item)
        {
            var dropPosition = player.transform.position + player.transform.forward * DropItemDistanceFromPlayer;
            item.ItemObjectReference.SetActive(true);
            item.ItemObjectReference.transform.position = dropPosition;
            _itemSlotsManipulator.ResetSlotFocus();
            PlayerInventory.RemoveItem(item);
        }
        
        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            InventoryEventHandler.OnInventoryChanged += () =>
            {
                ClearItemSlots();
                InventoryDataItemsToSlots();
                _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
            };
        }
    }
}