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
            EngineOfSoul soul = Instantiate(_prefabSoul, creationPosition, Quaternion.identity)
                .GetComponent<EngineOfSoul>();

            float duration = Vector3.Distance(creationPosition, endPosition) / _speed;
            soul.Init();
            soul.transform.SetParent(_thisTransform);
            soul.Move(endPosition, duration);
        }

        private void Start()
        {
            _thisTransform = transform;
        }
    }
}