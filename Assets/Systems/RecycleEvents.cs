using System;

namespace Systems
{
    public static class RecycleEvents
    {
        
        public static event Action OnTimerRunOut;
        public static event Action OnTimerWarning;
        public static event Action OnTimerDanger;
        public static event Action<int> OnSellItem;
        
        public static void SellItem(int price)
        {
            OnSellItem?.Invoke(price);
        }
        
        public static void TimerWarning()
        {
            OnTimerWarning?.Invoke();
        }
        
        public static void TimerDanger()
        {
            OnTimerDanger?.Invoke();
        }
        
        public static void TimerRunOut()
        {
            OnTimerRunOut?.Invoke();
        }
        
    }
}
