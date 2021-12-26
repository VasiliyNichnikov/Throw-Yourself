using System;

namespace MovingToAnotherObject
{
    public static class EventsMovingToAnotherObject
    {
        public static event Action<float> EventChangeLighting;

        public static void LauncherChangeLighting(float val)
        {
            EventChangeLighting?.Invoke(val);
        }
    }
}