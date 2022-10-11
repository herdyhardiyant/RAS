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

        [SerializeField] private VisualTreeAsset itemModalWindowTreeAsset;
        [SerializeField] private GameObject player;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _inventoryRoot;
        private VisualElement _itemSlots;
        private VisualElement _containerForItemModal;
        private int _playerInventoryItemCountBeforeInventoryChange;

        private VisualElement _lastSelectedSlot;
        private const int FocusBorderWidth = 2;
        private const int DefaultBorderWidth = 0;
        private const int DropItemDistanceFromPlayer = 2;
        
        private const string ItemSlotClass = "item-slot";

        void Awake()
        {
            _inventoryRoot = inventoryTreeAsset.CloneTree();
            _itemSlots = _inventoryRoot.Query<VisualElement>("item-slots");

            _containerForItemModal = _inventoryRoot.Query<VisualElement>("item-modal-container");
            _containerForItemModal.visible = false;

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

            for (var i = 0; i < maxItemSlots; i++)
            {
                var itemSlot = CreateItemSlot(i);

                _itemSlots.Add(itemSlot.contentContainer);
            }
        }

        private static VisualElement CreateItemSlot(int slotId)
        {
            var itemSlot = new VisualElement
            {
                name = "slot-" + slotId
            };
            
            itemSlot.AddToClassList(ItemSlotClass);

            itemSlot.style.borderLeftWidth = DefaultBorderWidth;
            itemSlot.style.borderRightWidth = DefaultBorderWidth;
            itemSlot.style.borderTopWidth = DefaultBorderWidth;
            itemSlot.style.borderBottomWidth = DefaultBorderWidth;

            itemSlot.style.borderLeftColor = Color.white;
            itemSlot.style.borderRightColor = Color.white;
            itemSlot.style.borderTopColor = Color.white;
            itemSlot.style.borderBottomColor = Color.white;
            return itemSlot;
        }

        private void CloseInventory()
        {
            StopFocusingLastSelectedSlot();

            _containerForItemModal.Clear();
            _containerForItemModal.visible = false;
        }

        private void BuildItemInInventoryDataToSlots()
        {
            var playerInventoryData = PlayerInventory.Inventory;

            for (int i = 0; i < playerInventoryData.Count; i++)
            {
                var itemSlot = _inventoryRoot.Query<VisualElement>($"slot-{i}").First();
                var item = playerInventoryData.ElementAt(i);
                itemSlot.style.backgroundImage = Background.FromRenderTexture(item.Image);

                //TODO on click slot, highlight border
                itemSlot.RegisterCallback<ClickEvent>(evt =>
                {
                    if (evt.propagationPhase != PropagationPhase.AtTarget)
                        return;

                    StopFocusingLastSelectedSlot();


                    FocusClickedItemSlot(itemSlot);

                    var itemModalWindow = BuildItemModalWindow(item);
                    ShowItemModal(itemModalWindow);
                });
            }
        }

        private void FocusClickedItemSlot(VisualElement itemSlot)
        {
            _lastSelectedSlot = itemSlot;

            itemSlot.style.borderLeftWidth = FocusBorderWidth;
            itemSlot.style.borderRightWidth = FocusBorderWidth;
            itemSlot.style.borderTopWidth = FocusBorderWidth;
            itemSlot.style.borderBottomWidth = FocusBorderWidth;
        }

        private void ClearItemSlots()
        {
            for (int i = 0; i < _playerInventoryItemCountBeforeInventoryChange; i++)
            {
                var itemSlot = _itemSlots.Query($"slot-{i}").First();
                itemSlot.style.backgroundImage = null;
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
            var itemModalWindow = itemModalWindowTreeAsset.CloneTree();
            itemModalWindow.Query<Label>("item-name").First().text = item.Name;
            itemModalWindow.Query<Label>("item-description").First().text = item.Description;
            itemModalWindow.Query<Button>("use-button").First().clicked += () => { print($"{item.Name} is used"); };
            itemModalWindow.Query<Button>("drop-button").First().clicked += () =>
            {
                DropItem(item);
                _containerForItemModal.Clear();
            };

            return itemModalWindow;
        }

        private void DropItem(ItemData item)
        {
            var dropPosition = player.transform.position + player.transform.forward * DropItemDistanceFromPlayer;
            item.ItemObjectReference.SetActive(true);
            item.ItemObjectReference.transform.position = dropPosition;
            StopFocusingLastSelectedSlot();
            PlayerInventory.RemoveItem(item);
        }

        private void StopFocusingLastSelectedSlot()
        {
            if (_lastSelectedSlot != null)
            {
                _lastSelectedSlot.style.borderLeftWidth = DefaultBorderWidth;
                _lastSelectedSlot.style.borderRightWidth = DefaultBorderWidth;
                _lastSelectedSlot.style.borderTopWidth = DefaultBorderWidth;
                _lastSelectedSlot.style.borderBottomWidth = DefaultBorderWidth;
            }
        }


        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            InventoryEventHandler.OnInventoryChanged += () =>
            {
                ClearItemSlots();
                BuildItemInInventoryDataToSlots();
                _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
            };
        }
    }
}