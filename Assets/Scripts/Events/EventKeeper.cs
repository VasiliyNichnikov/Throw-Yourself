using UnityEngine;

namespace Events
{
    [RequireComponent(typeof(MovingToAnotherObject), typeof(EnemyEvents))]
    public class EventKeeper : MonoBehaviour
    {
        public MovingToAnotherObject MovingToAnotherObject { get; private set; }
        public EnemyEvents EnemyEvents { get; private set; }
        public KillCounterEvents KillCounter { get; private set; }

        private void Awake()
        {
            MovingToAnotherObject = GetComponent<MovingToAnotherObject>();
            EnemyEvents = GetComponent<EnemyEvents>();
            KillCounter = GetComponent<KillCounterEvents>();
            InitAllEvents();
        }

        private void InitAllEvents()
        {
            MovingToAnotherObject.Init();
            EnemyEvents.Init();
            KillCounter.Init();
        }
    }
}