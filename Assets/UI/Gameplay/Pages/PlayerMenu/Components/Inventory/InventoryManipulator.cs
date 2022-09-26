using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _inventoryTreeAsset;
        private VisualElement _inventoryRoot;
        
        public VisualElement InventoryVisualElement => _inventoryRoot;
        
        void Awake()
        {
            _inventoryRoot = _inventoryTreeAsset.CloneTree();
            
        }
        
    }
}
