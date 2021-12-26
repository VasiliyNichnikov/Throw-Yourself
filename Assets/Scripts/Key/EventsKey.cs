using System;

namespace Key
{
    public static class EventsKey
    {
        public static event Action EventAddKey;

        public static void LauncherEventAddKey()
        {
            EventAddKey?.Invoke();
        }
    }
}