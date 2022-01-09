using UnityEngine;

namespace Player
{
    public class CreatorSoul : MonoBehaviour
    {
        [SerializeField, Header("Префаб души")]
        private GameObject _prefabSoul;

        [SerializeField, Header("Скорость перемещения"), Range(0, 20)]
        private float _speed;

        private Transform _thisTransform;

        public void CreateAndMove(Vector3 creationPosition, Vector3 endPosition)
        {
            float duration = GetDuration(creationPosition, endPosition);
            EngineOfSoul soul = GetNewSoul(creationPosition);
            soul.Move(endPosition, duration);
        }

        public void TransmigrationAfterCompletionOfSoulMovement(Vector3 creationPosition, Vector3 endPosition,
            EngineOfSoul.CompletionOfMovement action)
        {
            float duration = GetDuration(creationPosition, endPosition);
            EngineOfSoul soul = GetNewSoul(creationPosition);
            soul.Move(endPosition, duration, action);
        }

        private EngineOfSoul GetNewSoul(Vector3 creationPosition)
        {
            EngineOfSoul soul = Instantiate(_prefabSoul, creationPosition, Quaternion.identity)
                .GetComponent<EngineOfSoul>();
            soul.Init();
            soul.transform.SetParent(_thisTransform);
            return soul;
        }

        private float GetDuration(Vector3 creationPosition, Vector3 endPosition)
        {
            return Vector3.Distance(creationPosition, endPosition) / _speed;
        }

        private void Start()
        {
            _thisTransform = transform;
        }
    }
}