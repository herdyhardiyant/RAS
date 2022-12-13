using System;
using Interfaces;

namespace Systems
{
    public static class RecycleEvents
    {
        
        public static event Action OnTimerRunOut;
        public static event Action OnTimerWarning;
        public static event Action OnTimerDanger;
        public static event Action<ISellable> OnSellItem;
        
        public static void SellItem(ISellable sellObject)
        {
            OnSellItem?.Invoke(sellObject);
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
