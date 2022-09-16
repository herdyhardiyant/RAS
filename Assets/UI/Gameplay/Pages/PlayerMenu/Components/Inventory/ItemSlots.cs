using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Inventory
{
    [RequireComponent(typeof(UIDocument))]
    public class ItemSlots : MonoBehaviour
    {
        private const string ITEM_SLOTS_NAME = "item-slots";
        private const string ITEM_SLOT_STYLE_CLASS = "item-slot";
        [SerializeField] private int _maxSlots = 20;
        private VisualElement _rootInventory;
        private VisualElement _itemSlotsContainer;

        // Start is called before the first frame update
        void Start()
        {
            _rootInventory = GetComponent<UIDocument>().rootVisualElement;
            _itemSlotsContainer = _rootInventory.Query<VisualElement>(ITEM_SLOTS_NAME);

            // List<VisualElement> slots = createItemSlots();
            //
            // slots.ForEach(
            //     slot => { _itemSlotsContainer.Add(slot); }
            // );
        }
        
        private List<VisualElement> createItemSlots()
        {
            List<VisualElement> slots = new List<VisualElement>();
            
            for (int i = 0; i < _maxSlots; i++)
            {
                VisualElement newSlot = new VisualElement();
                newSlot.AddToClassList(ITEM_SLOT_STYLE_CLASS);
                newSlot.name = $"item-slot-{i}";
                slots.Add(newSlot);
            }

            return slots;
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}