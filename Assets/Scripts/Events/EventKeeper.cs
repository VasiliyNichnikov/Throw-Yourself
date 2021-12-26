using UnityEngine;

namespace Events
{
    [RequireComponent(typeof(MovingToAnotherObject), typeof(EnemyEvents))]
    public class EventKeeper : MonoBehaviour
    {
        public MovingToAnotherObject MovingToAnotherObject => _movingToAnotherObject;
        public EnemyEvents EnemyEvents => _enemyEvents;

        private MovingToAnotherObject _movingToAnotherObject;
        private EnemyEvents _enemyEvents;

        private void Awake()
        {
            _movingToAnotherObject = GetComponent<MovingToAnotherObject>();
            _enemyEvents = GetComponent<EnemyEvents>();

            InitAllEvents();
        }

        private void InitAllEvents()
        {
            _movingToAnotherObject.Init();
            _enemyEvents.Init();
        }
    }
}