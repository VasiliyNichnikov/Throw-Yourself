using System;

namespace Enemy
{
    public static class EventEnemy
    {
        public static event Action EventResetParameters;

        public static void LaunchEventResetParameters()
        {
            EventResetParameters?.Invoke();
        }
    }
}