using System;

namespace LifeSlider
{
    public class EventsLifeSlider
    {
        public static event Action<float> EventTakingDamage;

        public static void LauncherEventTakingDamage(float qty)
        {
            EventTakingDamage?.Invoke(qty);
        }
    }
}