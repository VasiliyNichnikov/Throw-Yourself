using System;
using UnityEngine;

namespace MovingToAnotherObject
{
    public static class EventChangerPlayerBody
    {
        public static event Action<Vector3> EventBeamThrow;
        public static event Action EventChangeBody;

        public static void LauncherEventBeamThrow(Vector3 direction)
        {
            EventBeamThrow?.Invoke(direction);
        }

        public static void LauncherEventChangeBody()
        {
            EventChangeBody?.Invoke();
        }
    }
}