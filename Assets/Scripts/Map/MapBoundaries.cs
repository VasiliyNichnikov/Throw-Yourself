using UnityEngine;

namespace Map
{
    public class MapBoundaries : MonoBehaviour
    {
        public Vector3[] Points => _points;

        public Vector3 RightUpCorner => _points[0];
        public Vector3 LeftBottomCorner => _points[1];

        [SerializeField] private Vector3[] _points;
        [SerializeField] private GameObject _objectForCalculatingBoundaries;

        public void CalculatePointsBoundaries()
        {
            if (_objectForCalculatingBoundaries == null) return;
            Collider collider = _objectForCalculatingBoundaries.GetComponent<Collider>();
            Bounds bounds = collider.bounds;
            Vector3 center = bounds.center;

            Vector3 rightUpCorner = bounds.ClosestPoint(new Vector3(Mathf.Infinity, center.y, Mathf.Infinity));
            Vector3 leftBottomCorner = bounds.ClosestPoint(new Vector3(-Mathf.Infinity, center.y, -Mathf.Infinity));
            _points[0] = rightUpCorner;
            _points[1] = leftBottomCorner;
        }

        private void Reset()
        {
            _points = new[]
            {
                new Vector3(0, 0, 1),
                new Vector3(0, 0, 2),
            };
        }
    }
}