using System;

namespace Systems
{
    public static class RecycleEvents
    {
        
        public static event Action OnTimerRunOut;
        
        public static void TimerRunOut()
        {
            OnTimerRunOut?.Invoke();
        }
        
    }
}
