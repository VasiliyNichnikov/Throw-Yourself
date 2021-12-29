using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class EnemyEvents : MonoBehaviour, IMyEvent
    {
        public UnityEvent ResetIsNoticesPlayer { get; private set; }

        public void Init()
        {
            ResetIsNoticesPlayer = new UnityEvent();
        }
    }
}