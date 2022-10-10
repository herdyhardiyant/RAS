using System.Linq;
using DataStorage;
using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _inventoryTreeAsset;
        private VisualElement _inventoryRoot;

        [SerializeField] private VisualTreeAsset _itemModalWindowTreeAsset;
        [SerializeField] private GameObject _player;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _itemSlots;
        private VisualElement _containerForItemModal;

        void Awake()
        {
            _inventoryRoot = _inventoryTreeAsset.CloneTree();
            _itemSlots = _inventoryRoot.Query<VisualElement>("item-slots");
            _containerForItemModal = _inventoryRoot.Query<VisualElement>("item-modal-container");
            _containerForItemModal.visible = false;
            SubscribeEvents();
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

        //TODO Split Item Modal Window into its own class
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
            itemModalWindow.Query<Button>("use-button").First().clicked += () => { print($"{item.name} is used"); };
            itemModalWindow.Query<Button>("drop-button").First().clicked += () => { DropItem(item); };
            return itemModalWindow;
        }

        private void DropItem(ItemData item)
        {
            PlayerInventory.RemoveItem(item);

            var dropPosition = _player.transform.position + _player.transform.forward * 2;
            
            Instantiate(item.prefab, dropPosition, Quaternion.identity);
        }

        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            InventoryEventHandler.onInventoryChanged += BuildItemInInventoryDataToSlots;
        }
    }
}