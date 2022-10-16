using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Crafting
{
    
    public class CraftingManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _craftingTreeAsset;
        private VisualElement _craftingVisualElement;

        public VisualElement CraftingVisualElement => _craftingVisualElement;
        
        void Awake()
        {
            _craftingVisualElement = _craftingTreeAsset.CloneTree();
        }


    }
}
