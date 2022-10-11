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
        private VisualElement _inventoryRoot;

        [SerializeField] private VisualTreeAsset itemModalWindowTreeAsset;
        [SerializeField] private GameObject player;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _itemSlots;
        private VisualElement _containerForItemModal;
        private int _playerInventoryItemCountBeforeInventoryChange;

        void Awake()
        {
            _inventoryRoot = inventoryTreeAsset.CloneTree();
            _itemSlots = _inventoryRoot.Query<VisualElement>("item-slots");
            _containerForItemModal = _inventoryRoot.Query<VisualElement>("item-modal-container");
            _containerForItemModal.visible = false;
            SubscribeEvents();

            _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
        }


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
            var maxItemSlots = PlayerInventory.MaxInventorySize;

            for (var i = 0; i < maxItemSlots; i++)
            {
                var itemSlot = new VisualElement();
                itemSlot.name = "slot-" + i;
                _itemSlots.Add(itemSlot.contentContainer);
                itemSlot.AddToClassList("item-slot");
            }
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

                    var itemModalWindow = BuildItemModalWindow(item);
                    ShowItemModal(itemModalWindow);
                });
            }
        }

        private void ClearItemSlots()
        {
            for (int i = 0; i < _playerInventoryItemCountBeforeInventoryChange; i++)
            {
                var itemSlot = _itemSlots.Query($"slot-{i}").First();
                itemSlot.style.backgroundImage = null;
            }
        }

        //TODO Split Item Modal Window into its own class
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
            var dropPosition = player.transform.position + player.transform.forward * 2;
            item.ItemObjectReference.SetActive(true);
            item.ItemObjectReference.transform.position = dropPosition;
            PlayerInventory.RemoveItem(item);
        }
        
        
        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            PlayerInventory.OnOnInventoryChanged += () =>
            {
                ClearItemSlots();
                BuildItemInInventoryDataToSlots();
                _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
            };
        }
    }
}