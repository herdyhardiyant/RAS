namespace EventSystems
{
    public static class InventoryEventHandler
    {
        public delegate void InventoryEvent();

        public static event InventoryEvent OnInventoryChanged;

        public static void ItemAdded()
        {
            OnInventoryChanged?.Invoke();
        }

        public static void ItemRemoved()
        {
            OnInventoryChanged?.Invoke();
        }
    }
}