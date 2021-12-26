using System;
using UnityEngine;

namespace PhysicsObjects
{
    public static class EventMovementObject
    {
        public static event Action<Vector3> EventMove;

        public static void LauncherEventMove(Vector3 direction)
        {
            EventMove?.Invoke(direction);
        }
    }
}