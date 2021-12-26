using UnityEngine;

namespace Enemy.Rifle
{
    public class EnemyRoute : MonoBehaviour
    {
        public Vector3[] MovingPoints => _movingPoints;
        [HideInInspector] public int IndexSelectedPoint = 0;

        private Transform _thisTransform;

        public Vector3 SelectedPoint
        {
            get
            {
                if (IndexSelectedPoint >= 0 && IndexSelectedPoint < _movingPoints.Length)
                    return _thisTransform.TransformPoint(_movingPoints[IndexSelectedPoint]);
                return Vector3.zero;
            }
        }

        [SerializeField] private Vector3[] _movingPoints;

        private void Start()
        {
            _thisTransform = transform;
        }

        private void Reset()
        {
            _movingPoints = new[] {new Vector3(0, 0, 1), new Vector3(0, 0, 2)};
        }
    }
}