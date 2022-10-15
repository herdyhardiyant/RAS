using System;
using DataStorage;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemActionWindow : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset itemActionWindowTreeAsset;
        [SerializeField] private InventoryController inventory;
        [SerializeField] private Transform playerPositionForItemDrop;

        private VisualElement _inventoryRoot;
        private VisualElement _itemActionWindow;

        private const string ActionWindowName = "action-window";
        private const string WindowContainerName = "item-modal-container";
        private const string UseButtonName = "use-button";
        private const string DropButtonName = "drop-button";

        private Label _itemName;
        private Label _itemDescription;

        private Button _useButton;
        private Button _dropButton;

        private Action _dropItem;
        private ItemData _itemData;


        public void ShowItemActionWindow(ItemData itemData)
        {
            _itemActionWindow.style.visibility = Visibility.Visible;
            _itemData = itemData;
            _itemName.text = itemData.Name;
            _itemDescription.text = itemData.Description;
        }

        public void Hide()
        {
            _itemActionWindow.style.visibility = Visibility.Hidden;
            _itemName.text = "";
            _itemDescription.text = "";
        }


        void Start()
        {
            _inventoryRoot = inventory.InventoryVisualElement;
            _itemActionWindow = itemActionWindowTreeAsset.CloneTree(ActionWindowName);

            QueryElements();

            AttachItemActionWindowToParentContainer();

            SubscribeActionsEvent();

            _itemActionWindow.style.visibility = Visibility.Hidden;
        }

        private void SubscribeActionsEvent()
        {
            _itemActionWindow.Q<Button>(UseButtonName).clicked += OnUseItem;
            _itemActionWindow.Q<Button>(DropButtonName).clicked += DropItem;
        }

        private void DropItem()
        {
            _itemData.ItemObjectReference.SetActive(true);
            _itemData.ItemObjectReference.transform.position =
                playerPositionForItemDrop.position + playerPositionForItemDrop.forward;
            PlayerInventory.RemoveItem(_itemData);

        }

        private void OnUseItem()
        {
            throw new NotImplementedException();
        }

        private void AttachItemActionWindowToParentContainer()
        {
            var renderContainer = _inventoryRoot.Query<VisualElement>(WindowContainerName).First();
            renderContainer.Add(_itemActionWindow);
        }

        private void QueryElements()
        {
            _itemName = _itemActionWindow.Query<Label>("item-name").First();
            _itemDescription = _itemActionWindow.Query<Label>("item-description").First();
            _useButton = _itemActionWindow.Q<Button>(UseButtonName);
            _dropButton = _itemActionWindow.Q<Button>(DropButtonName);
        }

        void OnDestroy()
        {
            UnsubscribeActionEvent();
        }

        private void UnsubscribeActionEvent()
        {
            _itemActionWindow.Q<Button>(UseButtonName).clicked -= OnUseItem;
            _itemActionWindow.Q<Button>(DropButtonName).clicked -= DropItem;
        }
    }
}