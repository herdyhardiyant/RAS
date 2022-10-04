using System;
using System.Linq;
using DataStorage;
using EventSystems;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _inventoryTreeAsset;
        private VisualElement _inventoryRoot;

        [SerializeField] private VisualTreeAsset _itemModalWindowTreeAsset;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _itemSlots;
        private VisualElement _containerForItemModal;


        void Awake()
        {
            _inventoryRoot = _inventoryTreeAsset.CloneTree();
            _itemSlots = _inventoryRoot.Query<VisualElement>("item-slots");
            _containerForItemModal = _inventoryRoot.Query<VisualElement>("item-modal-container");
            InventoryEventHandler.onInventoryChanged += FetchInventoryDataToSlots;

            _containerForItemModal.visible = false;
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
        }

        /// <summary>
        /// Handle weird bug where this ItemModal
        /// is still showing up even though the root is set to not visible.
        /// Use this to hide ItemModal when inventory root visual element is set to not visible.
        /// </summary>
        private void CloseInventory()
        {
            _containerForItemModal.Clear();
            _containerForItemModal.visible = false;
        }

        private void Start()
        {
            CreateItemSlots();
        }

        private void CreateItemSlots()
        {
            //TODO Create Slot Class and Handle all slot functionality there.
            var maxItemSlots = PlayerInventory.MaxInventorySize;

            for (var i = 0; i < maxItemSlots; i++)
            {
                var itemSlot = new VisualElement();
                itemSlot.name = "slot-" + i;
                _itemSlots.Add(itemSlot.contentContainer);
                itemSlot.AddToClassList("item-slot");
            }
        }

        private void FetchInventoryDataToSlots()
        {
            var playerInventoryData = PlayerInventory.Inventory;
            for (int i = 0; i < playerInventoryData.Count; i++)
            {
                var itemSlot = _inventoryRoot.Query<VisualElement>($"slot-{i}").First();
                var item = playerInventoryData.ElementAt(i);
                itemSlot.style.backgroundImage = Background.FromRenderTexture(item.image);

                //TODO on click slot, highlight border
                itemSlot.RegisterCallback<ClickEvent>(evt =>
                {
                    if (evt.propagationPhase != PropagationPhase.AtTarget)
                        return;

                    var itemModalWindow = BuildItemModalWindow(item);
                    ShowItemModal(itemModalWindow);
                });
            }
        }

        private void ShowItemModal(TemplateContainer itemModalWindow)
        {
            _containerForItemModal.visible = true;
            _containerForItemModal.Clear();
            _containerForItemModal.Add(itemModalWindow);
        }

        private TemplateContainer BuildItemModalWindow(ItemData item)
        {
            var itemModalWindow = _itemModalWindowTreeAsset.CloneTree();
            itemModalWindow.Query<Label>("item-name").First().text = item.name;
            itemModalWindow.Query<Label>("item-description").First().text = item.description;
            //TODO Create Drop Method to spawn item to the world and delete from inventory
            itemModalWindow.Query<Button>("use-button").First().clicked += () => { print($"{item.name} is used"); };
            itemModalWindow.Query<Button>("drop-button").First().clicked += () => { print($"{item.name} is dropped"); };
            return itemModalWindow;
        }
    }
}