using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemActionWindow: MonoBehaviour
    {
        
        [SerializeField] private VisualTreeAsset itemActionWindowTreeAsset;
        [SerializeField] private InventoryManipulator inventory;

        private VisualElement _inventoryRoot;
        private VisualElement _itemActionWindow;
       
        
        void Start()
        {
            _inventoryRoot = inventory.InventoryVisualElement;
            _itemActionWindow = itemActionWindowTreeAsset.CloneTree();
            _inventoryRoot.Add(_itemActionWindow);
            _itemActionWindow.style.display = DisplayStyle.None;
        }
        
        
        void Update()
        {
        
        }
    }
}
