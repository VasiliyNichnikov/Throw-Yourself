using System;
using Map;
using UnityEngine;

namespace MainCamera
{
    public class CalculatorCameraPosition : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private MapBoundaries _boundaries;
        private Transform _thisTransform;
        private Vector3 _hitPoint;

        public Vector3 GetMovementPosition(Vector3 targetPosition)
        {
            Vector3 difference = _hitPoint - targetPosition;
            var position = _thisTransform.position;
            Vector3 positionEnd = new Vector3(position.x - difference.x, position.y, position.z - difference.z);
            return ClampPositionEnd(positionEnd);
        }

        private void Start()
        {
            _hitPoint = Vector3.zero;
            _thisTransform = transform;
            _boundaries = FindObjectOfType<MapBoundaries>();
            if (_boundaries == null) throw new Exception("Map borders were not found.");
        }

        private void FixedUpdate()
        {
            Debug.DrawRay(_thisTransform.position, _thisTransform.TransformDirection(Vector3.forward) * 100f,
                Color.yellow);

            if (Physics.Raycast(_thisTransform.position, _thisTransform.TransformDirection(Vector3.forward),
                    out var hit, 100.0f, _layerMask.value) == false) return;

            _hitPoint = hit.point;
        }

        private Vector3 ClampPositionEnd(Vector3 positionEnd)
        {
            Vector3 rightUpCorner = _boundaries.RightUpCorner;
            Vector3 leftBottomCorner = _boundaries.LeftBottomCorner;

            positionEnd.x = Mathf.Clamp(positionEnd.x, leftBottomCorner.x, rightUpCorner.x);
            positionEnd.z = Mathf.Clamp(positionEnd.z, leftBottomCorner.z, rightUpCorner.z);
            return positionEnd;
        }

        private void OnDrawGizmos()
        {
            if (_hitPoint == Vector3.zero) return;
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(_hitPoint, 0.15f);
        }
    }
}